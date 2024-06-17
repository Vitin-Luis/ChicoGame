using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{   
    public string message;
    [SerializeField] GameObject arvore;
    [SerializeField] ParticleSystem particula;
    [SerializeField] public bool interagido;
    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {   
        interagido = false;
        if (arvore != null)
        {
            arvore.SetActive(false);
        }
        DisableOutline();
    }
    public void Interact()
    {
        arvore.SetActive(true);
        particula.Stop();
        interagido = true;
    }
    public void Reset()
    {
        interagido = false;
        arvore.SetActive(false);
        DisableOutline();
        particula.Play();
    }
    public void DisableOutline()
    {
    }
    public void EnableOutline()
    {
    }

    // Update is called once per frame
}
