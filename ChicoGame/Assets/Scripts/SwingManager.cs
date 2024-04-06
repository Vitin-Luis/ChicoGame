using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingManager : MonoBehaviour
{
    // Variáveis para controle do balanço
    public float swayAmount = 1.4f; // Quão longe o barco vai balançar
    public float swaySpeed = 0.4f; // Velocidade do balanço
    public float swayFrequency = 0.5f; // Frequência do balanço

    // Variáveis internas
    private float timer = 0.0f;
    private float randomOffset;

    void Start()
    {
        // Gera um offset aleatório para o balanço
        randomOffset = Random.Range(0.0f, 100.0f);
    }

    void Update()
    {
        // Incrementa o tempo baseado na velocidade do balanço
        timer += Time.deltaTime * swaySpeed;

        // Calcula a posição de balanço baseada no tempo e frequência
        float swayOffset = Mathf.Sin(timer * Mathf.PI * 2 * swayFrequency + randomOffset) * swayAmount;

        // Aplica a rotação para simular o balanço
        transform.rotation = Quaternion.Euler(swayOffset, 0.0f, swayOffset);
    }
}
