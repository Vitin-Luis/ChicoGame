using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject healingBox;
    public GameObject[] AIArray;
    public GameObject[] BoxArray;
    public float spawnInterval = 3f;
    public int maxInstances = 5;
    public int maxBox = 10;
    [SerializeField] ScoreManager scoreScreen;
    [SerializeField] HealthBar bossBar;
    [SerializeField] GameObject Boss;

    private int currentInstances = 0;
    private int currentBoxInstances = 0;

    public static bool fase2;

    void Start()
    {
        fase2 = false;
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }
    void Update()
    {
        AIArray = GameObject.FindGameObjectsWithTag("Enemy");
        currentInstances = AIArray.Length;
        if (ScoreManager.scoreCount >= 30)
        {
            fase2 = true;
            SpawnBoss();
        }
    }

    void SpawnPrefab()
    {
        if (AIArray.Length < maxInstances && fase2 == false){
            Vector3 randomPosition = RandomNavMeshPosition();
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
            currentInstances++;
        }
        if (BoxArray.Length < maxBox){
            Vector3 randomPosition = RandomNavMeshPosition();
            Instantiate(healingBox, randomPosition, Quaternion.identity);
            currentBoxInstances++;
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
    void SpawnBoss()
    {
        scoreScreen.Disabled();
        bossBar.Setup();
        if (Boss)
        {
            Boss.SetActive(true);
        }
    }
}