using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishingArea : MonoBehaviour
{
    //[SerializeField] private StartFishing startFishing;

    private List<GameObject> spawnedFish;

    private void Awake()
    {
        //startFishing = GetComponent<StartFishing>();
        spawnedFish = new List<GameObject>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void AddSpawnedFish(GameObject fish)
    {
        spawnedFish.Add(fish);
    }

    public int GetCurrentSpawnedFish()
    {
        return spawnedFish.Count;
    }

    public GameObject GetClosestFish(Vector3 playerPos)
    {
        float nearestFish = float.PositiveInfinity;
        GameObject currentClosestFish = null; 

        foreach (GameObject fish in spawnedFish)
        {
            Vector3 fishLocation = fish.transform.position;
            float distanceToFishSq = (playerPos - fishLocation).sqrMagnitude;

            if (distanceToFishSq < nearestFish)
            {
                nearestFish = distanceToFishSq;
                currentClosestFish = fish;
            }
        }

        Debug.Log(currentClosestFish);
        return currentClosestFish;
    }

    private void CatchClosestFish()
    {
        
    }
}
