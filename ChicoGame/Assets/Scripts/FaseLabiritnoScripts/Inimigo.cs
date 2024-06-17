using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    public float vida = 50f;
    private Animator inimigoAnimacao;
    public Transform player;
    private NavMeshAgent agent;
    private AISpawner spawner;

    private void Start()
    {
        inimigoAnimacao = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        spawner = FindObjectOfType<AISpawner>();
    }

    private void Update()
    {
        
        agent.destination = player.position;
        if (inimigoAnimacao != null)
        {
            inimigoAnimacao.SetTrigger("triggerAndar");
        }
    }
    
    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.InstanceDestroyed();
        }
    }

    void Atacar()
    {
        inimigoAnimacao.SetTrigger("triggerAtacar");
    }
    
    // Start is called before the first frame update
    public void TomarDano(float quantidade)
    {
        vida -= quantidade;
        if (vida <= 0f)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        
        inimigoAnimacao.SetTrigger("triggerMorrer");
        Destroy(gameObject);
    }
    
}
