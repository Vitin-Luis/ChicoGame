using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela : MonoBehaviour
{
    // Start is called before the first frame update
    public TelaPerdeu TelaPerdeu;
    public TelaGanhou TelaGanhou;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EndGame();
        }
        if (other.gameObject.CompareTag("Tesouro"))
        {
            Ganhou();
            Debug.Log("colidiu");
        }
        
    }
    
    void EndGame()
    {
        TelaPerdeu.Setup();
    }

    void Ganhou()
    {
        TelaGanhou.Setup();
    }
    
}
