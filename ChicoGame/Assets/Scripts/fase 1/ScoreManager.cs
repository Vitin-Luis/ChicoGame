using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Classe para controlar o score
public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public static int scoreCount;
    
    void Start()
    {
        
    }

    public void Disabled()
    {
        gameObject.SetActive(false);
    }

    // Método que atualiza score
    void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}
