using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject[] AIArray;
    public float spawnInterval = 3f;
    public int maxInstances = 7;

    private int currentInstances = 0;

    void Start()
    {
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }
    void Update()
    {
        AIArray = GameObject.FindGameObjectsWithTag("Enemy");
        currentInstances = AIArray.Length;
    }

    void SpawnPrefab()
    {

        if (AIArray.Length < maxInstances)
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
            randomPosition = transform.position + Random.insideUnitSphere * 1000f;
        }
        return hit.position;
    }

    public void InstanceDestroyed()
    {
        currentInstances--;
    }
}