using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SpawnFish : MonoBehaviour
{
    [SerializeField] private List<GameObject> splineAquaticLife;
    [SerializeField] private SplineContainer splineObject;

    private List<GameObject> spawnedFish;

    private void Awake()
    {
        spawnedFish = new List<GameObject>();
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
        foreach (GameObject fish in splineAquaticLife)
        {
            // Getting random num & spline location to instantiate fish at random location
            float fishInstantiatePoint = Random.Range(0f, 1f);
            Vector3 position = splineObject.EvaluatePosition(fishInstantiatePoint);

            // Getting fish instance to add to spawn list and start animation
            GameObject instancedFish = Instantiate(fish, position, Quaternion.identity);
            spawnedFish.Add(instancedFish);

            SplineAnimate splineAnimate = instancedFish.GetComponent<SplineAnimate>();

            if (splineAnimate != null)
            {
                splineAnimate.Container = splineObject;
                splineAnimate.Play();   
            }
        }
    }

    private void CheckFishPop()
    {
        if (spawnedFish.Count < 3 && !(spawnedFish.Count > 7))
        {
            GenerateFish();
        }
    }

    /*private void DestroyFish()
    {
        float destroyDelay = 3f * Time.deltaTime;
        foreach (GameObject fish in spawnedFish)
        {
            spawnedFish.Remove(fish);
            Destroy(fish, destroyDelay);
        }
    }*/
}
