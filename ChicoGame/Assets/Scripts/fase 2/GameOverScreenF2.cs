using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenF2 : MonoBehaviour
{
    float timer;
    [SerializeField] GameController gameController;
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            gameObject.SetActive(false);
            gameController.Restart();
        }
    }
}
