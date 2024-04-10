using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    public ParticleSystem flash;
    // Start is called before the first frame update
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
