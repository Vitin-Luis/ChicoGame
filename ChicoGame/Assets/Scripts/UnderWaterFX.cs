using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterFX : MonoBehaviour
{
    public Material waterMaterial; // Referência ao material da água com o efeito de neblina
    private bool isInsideWater = false; // Variável para controlar se a câmera está dentro da água

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Main Camera")) // Substitua "Player" pelo tag do objeto que possui a câmera
        {
            isInsideWater = true;
            RenderSettings.fog = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Main Camera")) // Substitua "Player" pelo tag do objeto que possui a câmera
        {
            isInsideWater = false;
            RenderSettings.fog = true;
        }
    }
}
