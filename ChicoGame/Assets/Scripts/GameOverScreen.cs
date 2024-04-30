using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    
}
