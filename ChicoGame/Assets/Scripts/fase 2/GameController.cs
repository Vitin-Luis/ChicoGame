using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Timer playerTimer;
    [SerializeField] Interactable[] pontos;
    [SerializeField] Interactable ultimoPonto;
    [SerializeField] OtherController oc;
    [SerializeField] GameOverScreenF2 gameOverScreen;
    [SerializeField] Concluiu passouScreen;
    public bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ultimoPonto.interagido == false && playerTimer.tempoRestante <= 0)
        {
            GameOver();
        }
        if (gameRunning == true && ultimoPonto.interagido == true && playerTimer.tempoRestante >= 0)
        {
            gameRunning = false;
            passouScreen.Setup();
        }
        if(oc.started == true)
        {
            playerTimer.ready = true;
        }
    }

    public void Restart()
    {
        player.transform.position = new Vector3(459.408051f, 76.4931412f, 586.374878f);
        oc.started = false;
        playerTimer.ready = false;
        playerTimer.timerText.enabled = false;
        playerTimer.tempoRestante = 75;
        foreach(Interactable p in pontos)
        {
            p.Reset();
        }
    }
    void GameOver()
    {
        gameOverScreen.Setup();
    }
}
