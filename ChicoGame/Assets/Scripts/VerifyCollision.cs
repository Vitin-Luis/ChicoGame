using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyCollision : MonoBehaviour
{
    public bool ableToFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToFire = true;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToFire = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ableToFire = false;
        }
    }
    public bool isInRange()
    {
        return ableToFire;
    }
}
