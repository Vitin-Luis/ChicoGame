using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    public ParticleSystem flash;
    void Start()
    {
        flash = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayParticle()
    {
        if (flash != null)
        {
            flash.Play();
        }
    }
}
