using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabRandomly : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 3f;
    public int maxInstances = 5; 

    private int currentInstances = 0; 

    void Start()
    {
        
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        
        if (currentInstances < maxInstances)
        {
            
            Vector3 randomPosition = RandomNavMeshPosition();

            
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
            
            
            currentInstances++;
        }
    }

    Vector3 RandomNavMeshPosition()
    {
        UnityEngine.AI.NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        while (!UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            randomPosition = transform.position + Random.insideUnitSphere * 10f;
        }
        return hit.position;
    }
    
    public void InstanceDestroyed()
    {
        currentInstances--;
    }
}