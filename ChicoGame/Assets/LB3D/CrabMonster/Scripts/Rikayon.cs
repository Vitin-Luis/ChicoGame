using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour
{

	private Animator m_Animator;
	private float tempoEntreAtaques = 3f; // Tempo em segundos entre os ataques
	private float tempoPassado = 0f;

	private string[] triggers = { "Attack_1", "Attack_2", "Attack_3" }; // Lista de triggers

	private void Start()
	{
		m_Animator = GetComponent<Animator>();
	}

	private void Update()
	{
		// Conta o tempo passado
		tempoPassado += Time.deltaTime;

		// Se o tempo passado for maior ou igual ao intervalo desejado, ativa um trigger aleatório
		if (tempoPassado >= tempoEntreAtaques)
		{
			int indiceAleatorio = Random.Range(0, triggers.Length);
			m_Animator.SetTrigger(triggers[indiceAleatorio]);
			tempoPassado = 0f; // Reinicia o contador
		}
	}
}
