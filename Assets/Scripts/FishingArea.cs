using System.Collections.Generic;
using UnityEngine;

public class FishingArea : MonoBehaviour
{
    [SerializeField] private ScoreBoard _scoreBoard;

    private FishData _fishInfo;
    private List<GameObject> _spawnedFish;

    private int _points;
    public int Points => _points;

    private void Awake()
    {
        _spawnedFish = new List<GameObject>();
    }

    public void AddSpawnedFish(GameObject fish)
    {
        _spawnedFish.Add(fish);
    }

    public int GetCurrentSpawnedFish()
    {
        return _spawnedFish.Count;
    }

    private GameObject GetClosestFish(Vector3 playerPos)
    {
        float nearestFish = float.PositiveInfinity;
        GameObject currentClosestFish = null; 

        foreach (GameObject fish in _spawnedFish)
        {
            Vector3 fishLocation = fish.transform.position;
            float distanceToFishSq = (playerPos - fishLocation).sqrMagnitude;

            if (distanceToFishSq < nearestFish)
            {
                nearestFish = distanceToFishSq;
                currentClosestFish = fish;
            }
        }

        _fishInfo = currentClosestFish.GetComponent<FishData>();
        Debug.Log($"Species: {_fishInfo.Species}, Rarity: {_fishInfo.Rarity}, Points: {_fishInfo.Points}");
        return currentClosestFish;
    }

    private void AddScoreToScoreBoard(int amount)
    {
        _scoreBoard.AddScore(amount);
    }
    public int CatchFish(Vector3 playerPos)
    {
        GameObject fish = GetClosestFish(playerPos);
        
        if (fish == null)
        {
            return 0;
        }

        _points = _fishInfo.Points;
        Debug.Log($"Points added: {_points}");

        AddScoreToScoreBoard(_points);

        _spawnedFish.Remove(fish);
        Destroy(fish.gameObject);

        return _points;
    }    
}
