using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerRange = 3f;
    Interactable currentInteractable;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if(Physics.Raycast(ray, out hit, playerRange)) 
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable> ();
                if(newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
            }
        }
    }
    void SetNewCurrentInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
        currentInteractable.EnableOutline();
    }
    void DisableInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
