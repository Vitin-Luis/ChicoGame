using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rikayon : MonoBehaviour {

    private Animator m_Animator;
    private float tempoEntreAtaques = 3f;
    private float tempoPassado = 0f;

    private string[] triggers = { "Attack_1", "Attack_2", "Attack_3", "Attack_5", "Intimidate_1", "Intimidate_2" };

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {

        tempoPassado += Time.deltaTime;


        if (tempoPassado >= tempoEntreAtaques)
        {
            int indiceAleatorio = Random.Range(0, triggers.Length);
            m_Animator.SetTrigger(triggers[indiceAleatorio]);
            tempoPassado = 0f; // Reinicia o contador
        }
    }
}
