using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI; // Certifique-se de que isso est� inclu�do para usar UnityEngine.UI.Image
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerRun : MonoBehaviour
{
    int score;
    public static GameManagerRun inst;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelCompleteText;
    public UnityEngine.UI.Image backgroundImage; // Use o namespace completo

    public PlayerMovment playerMovement;

    void Awake()
    {
        inst = this;
        levelCompleteText.gameObject.SetActive(false);
        backgroundImage.gameObject.SetActive(false); // Hide the background image initially
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "VINHO: " + score;

        playerMovement.speed += playerMovement.speedIncreasePerPoint;

        if (score >= 10)
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        levelCompleteText.text = "Nívél Cóncluídó";
        levelCompleteText.gameObject.SetActive(true);
        backgroundImage.gameObject.SetActive(true); // Show the background image
        playerMovement.enabled = false; // Disable player movement
        StartCoroutine(WaitAndLoadNextScene());
    }
    
    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(3); // Espera por 3 segundos
        SceneManager.LoadScene("Fase3"); // Troca para a cena desejada
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize or other logic
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic
    }
}
