using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{   
    public string message;
    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        DisableOutline();
    }
    public void Interact()
    {
        onInteraction.Invoke();
    }
    public void DisableOutline()
    {
    }
    public void EnableOutline()
    {
    }

    // Update is called once per frame
}
