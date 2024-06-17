using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] public float tempoRestante;
    public bool ready;
    void Start()
    {
        timerText.color = Color.red;
        ready = false;
        timerText.enabled = false;
    }

    void Update()
    {
        if(ready)
        {
            timerText.enabled = true;
            if (tempoRestante > 0)
            {
                tempoRestante -= Time.deltaTime;
            }else
            {
                tempoRestante = 0;
                timerText.color = Color.red;
            }
            int minutos = Mathf.FloorToInt(tempoRestante / 60);
            int segundos = Mathf.FloorToInt(tempoRestante % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        
    }
}
