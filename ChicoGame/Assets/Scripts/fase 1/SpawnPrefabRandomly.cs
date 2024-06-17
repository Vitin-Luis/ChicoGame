using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável por spawnar prefabs aleatoriamente em locais válidos do NavMesh
public class SpawnPrefabRandomly : MonoBehaviour
{
    // Prefab a ser spawnado
    public GameObject prefabToSpawn;

    // Intervalo de tempo entre cada spawn
    public float spawnInterval = 3f;

    // Número máximo de instâncias permitidas
    public int maxInstances = 5;

    // Número atual de instâncias
    public int currentInstances = 0;

    // Inicialização
    void Start()
    {
        // Invoca repetidamente o método SpawnPrefab com base no spawnInterval
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    // Método para spawnar um prefab
    public void SpawnPrefab()
    {
        // Verifica se o número atual de instâncias é menor que o máximo permitido
        if (currentInstances < maxInstances)
        {
            // Obtém uma posição aleatória no NavMesh
            Vector3 randomPosition = RandomNavMeshPosition();
            
            // Instancia o prefab na posição aleatória
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
            
            // Incrementa o número de instâncias atuais
            currentInstances++;
        }
    }

    // Método para obter uma posição aleatória no NavMesh
    Vector3 RandomNavMeshPosition()
    {
        UnityEngine.AI.NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        
        // Enquanto não encontrar uma posição válida no NavMesh, continua procurando
        while (!UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            // Gera uma posição aleatória dentro de uma esfera com raio 10 centrada na posição do objeto
            randomPosition = transform.position + Random.insideUnitSphere * 10f;
        }
        return hit.position;
    }

    // Método para destruir um prefab e decrementar o número de instâncias atuais
    public void DestroyPrefab()
    {
        currentInstances--;
    }
}