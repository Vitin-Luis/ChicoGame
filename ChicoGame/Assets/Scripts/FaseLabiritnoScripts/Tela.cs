using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela : MonoBehaviour
{
    // Start is called before the first frame update
    public TelaPerdeu TelaPerdeu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EndGame();
        }
    }
    
    void EndGame()
    {
        TelaPerdeu.Setup();
        
    }
    
}
