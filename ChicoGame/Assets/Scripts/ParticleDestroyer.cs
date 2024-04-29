using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{

    void Start()
    {
        // Destroi particula
        Destroy(gameObject, 3.5f);
    }
}
