using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory : MonoBehaviour
{
    public ParticleSystem splash;
    private Rigidbody Proj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up * 50f * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        Instantiate(splash, transform.position, splash.transform.rotation);

        Destroy(gameObject);
    }
}
