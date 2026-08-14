using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SpawnFish : MonoBehaviour
{
    [SerializeField] private List<GameObject> splineAquaticLife;
    [SerializeField] private SplineContainer splineObject;
    [SerializeField] private Transform spawnedFishGroup;

    [SerializeField] private int minFish;
    [SerializeField] private int maxFish;

    private List<float> fishSplinePositions = new List<float>();

    private FishingArea fishingArea;

    private void Awake()
    {
        fishingArea = GetComponentInParent<FishingArea>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GenerateFish();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckFishPop();
    }

    private void GenerateFish()
    {
        int randomFishNum = Random.Range(minFish, maxFish);

        for (int i = 0; i < randomFishNum; i++)
        {
            GameObject selectedFish = PickFish(splineAquaticLife);
            InstantiateFish(selectedFish);
        }
    }

    private GameObject PickFish(List<GameObject> serializedList)
    {
        int randomIndex = Random.Range(0, serializedList.Count);
        
        return serializedList[randomIndex];
    }

    private void InstantiateFish(GameObject selectedFish)
    {
        int maxAttempts = 0;
        float fishInstantiatePoint = Random.Range(0f, 1f);
        bool isValidDistance = FishDistanceCheck(fishInstantiatePoint);

        while (!isValidDistance && maxAttempts <= 10)
        {
            fishInstantiatePoint = Random.Range(0f, 1f);
            isValidDistance = FishDistanceCheck(fishInstantiatePoint);
            maxAttempts++;
        }
        
        fishSplinePositions.Add(fishInstantiatePoint);

        // Getting fish instance to add to spawn list and start animation
        Vector3 position = splineObject.EvaluatePosition(fishInstantiatePoint);
        GameObject instancedFish = Instantiate(selectedFish, position, Quaternion.identity, spawnedFishGroup);
        
        // Adding fish for fishingArea's list
        fishingArea.AddSpawnedFish(instancedFish);

        SplineAnimate splineAnimate = instancedFish.GetComponent<SplineAnimate>();

        if (splineAnimate != null)
        {
            splineAnimate.Container = splineObject;
            splineAnimate.StartOffset = fishInstantiatePoint;
            splineAnimate.Play();   
        }
    }

    private bool FishDistanceCheck(float spawnPoint)
    {
        float minDistance = 0.3f;
        bool distanceCheck = true;

        foreach (float point in fishSplinePositions)
        {
            float distanceBetweenPoints = Mathf.Abs(spawnPoint - point);

            if (distanceBetweenPoints < minDistance)
            {
                distanceCheck = false;
                return distanceCheck;
            }
        }

        return distanceCheck;
    }

    private void CheckFishPop()
    {
        if (fishingArea.GetCurrentSpawnedFish() < minFish && 
            !(fishingArea.GetCurrentSpawnedFish() > maxFish))
        {
            GenerateFish();
        }
    }
}
