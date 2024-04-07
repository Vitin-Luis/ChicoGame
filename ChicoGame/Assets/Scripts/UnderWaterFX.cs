using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterFX : MonoBehaviour
{
    public Material waterMaterial; // Refer�ncia ao material da �gua com o efeito de neblina
    private bool isInsideWater = false; // Vari�vel para controlar se a c�mera est� dentro da �gua

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Main Camera")) // Substitua "Player" pelo tag do objeto que possui a c�mera
        {
            isInsideWater = true;
            RenderSettings.fog = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Main Camera")) // Substitua "Player" pelo tag do objeto que possui a c�mera
        {
            isInsideWater = false;
            RenderSettings.fog = true;
        }
    }
}
