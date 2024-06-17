using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Arma : MonoBehaviour
{
    // Propriedades da arma
    public float dano = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public Camera fpsCam;
    public GameObject MuzzleFlash;
    public ParticleSystem fumacaTiro;
    public GameObject impacto;
    public Transform MuzzlePosition;

    // Variável privada para controlar a taxa de tiro
    private float proximoTempoDeDisparo = 0f;

    // Update é chamado uma vez por frame
    void Update()
    {
        // Verifica se o botão de fogo está pressionado e se o tempo atual é maior ou igual ao próximo tempo permitido para disparo
        if (Input.GetButtonDown("Fire1") && Time.time >= proximoTempoDeDisparo)
        {
            // Calcula o próximo tempo permitido para disparo
            proximoTempoDeDisparo = Time.time + 1f / fireRate;
            Atirar();
        }
    }

    void Atirar()
    {
        // Reproduz a partícula de fumaça do tiro
        fumacaTiro.Play();

        // Instancia o efeito de flash do cano da arma e o destrói após 0.2 segundos
        GameObject flash = Instantiate(MuzzleFlash, MuzzlePosition.position, MuzzlePosition.rotation, MuzzlePosition);
        Destroy(flash, 0.2f);

        // Realiza o raycast para detectar colisões
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // Verifica se o objeto atingido tem o componente "Inimigo" e aplica dano
            Inimigo inimigo = hit.transform.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.TomarDano(dano);
            }

            // Instancia o efeito de impacto no ponto de colisão
            Instantiate(impacto, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}

