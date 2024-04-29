using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Classe responsável por spawnar inteligências artificiais (IA) aleatoriamente em locais válidos do NavMesh
public class AISpawner : MonoBehaviour
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

    // Método para spawnar um prefab da IA
    public void SpawnPrefab()
    {
        // Verifica se o número atual de instâncias é menor que o máximo permitido
        if (currentInstances < maxInstances)
        {
            // Obtém uma posição aleatória no NavMesh
            Vector3 randomPosition = RandomNavMeshPosition();
            
            // Instancia o prefab da IA na posição aleatória
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
            // Gera uma posição aleatória dentro de uma esfera com raio 1000 centrada na posição do objeto
            randomPosition = transform.position + Random.insideUnitSphere * 1000f;
        }
        return hit.position;
    }

    // Método chamado quando uma instância é destruída, decrementando o número de instâncias atuais
    public void InstanceDestroyed()
    {
        currentInstances--;
    }
}

