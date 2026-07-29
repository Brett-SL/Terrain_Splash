using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SpawnFish : MonoBehaviour
{
    [SerializeField] private List<GameObject> seaAquaticLife;
    [SerializeField] private SplineContainer splineObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateFish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateFish()
    {
        foreach (GameObject fish in seaAquaticLife)
        {
            float fishInstantiatePoint = Random.Range(0f, 1f);
            Vector3 position = splineObject.EvaluatePosition(fishInstantiatePoint);

            GameObject instancedFish = Instantiate(fish, position, Quaternion.identity);
            SplineAnimate splineAnimate = instancedFish.GetComponent<SplineAnimate>();

            if (splineAnimate != null)
            {
                splineAnimate.Container = splineObject;   
            }
        }
    }
}
