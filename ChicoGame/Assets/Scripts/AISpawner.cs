using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    public GameObject AIPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 5f;
    public int maxNumberOfAI = 5;

    private int currentNumberOfAI = 0;
    private float timer = 0f;

    void Start()
    {
        SpawnAI();
    }

    void Update()
    {
        if (currentNumberOfAI < maxNumberOfAI)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnAI();
                timer = 0f;
            }
        }
    }

    void SpawnAI()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
        Vector3[] navMeshVertices = navMeshData.vertices;
        Vector3 randomPoint = navMeshVertices[Random.Range(0, navMeshVertices.Length)];
        Vector3 spawnPosition = randomPoint + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f;

        GameObject ai = Instantiate(AIPrefab, spawnPosition, Quaternion.identity);
        ai.transform.parent = transform;

        currentNumberOfAI++;
    }
}
