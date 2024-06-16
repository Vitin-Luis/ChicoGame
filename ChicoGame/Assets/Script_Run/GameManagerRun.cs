using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI; // Certifique-se de que isso está incluído para usar UnityEngine.UI.Image
using TMPro;

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

        if (score >= 50)
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        levelCompleteText.text = "Nível concluído!";
        levelCompleteText.gameObject.SetActive(true);
        backgroundImage.gameObject.SetActive(true); // Show the background image
        playerMovement.enabled = false; // Disable player movement
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
