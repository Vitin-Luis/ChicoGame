using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingManager : MonoBehaviour
{
    // Vari�veis para controle do balan�o
    public float swayAmount = 1.4f; // Qu�o longe o barco vai balan�ar
    public float swaySpeed = 0.4f; // Velocidade do balan�o
    public float swayFrequency = 0.5f; // Frequ�ncia do balan�o

    // Vari�veis internas
    private float timer = 0.0f;
    private float randomOffset;

    void Start()
    {
        // Gera um offset aleat�rio para o balan�o
        randomOffset = Random.Range(0.0f, 100.0f);
    }

    void Update()
    {
        // Incrementa o tempo baseado na velocidade do balan�o
        timer += Time.deltaTime * swaySpeed;

        // Calcula a posi��o de balan�o baseada no tempo e frequ�ncia
        float swayOffset = Mathf.Sin(timer * Mathf.PI * 2 * swayFrequency + randomOffset) * swayAmount;

        // Aplica a rota��o para simular o balan�o
        transform.rotation = Quaternion.Euler(swayOffset, 0.0f, swayOffset);
    }
}
