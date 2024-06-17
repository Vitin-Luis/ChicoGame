using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherController : MonoBehaviour
{
    public bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("start"))
        {
            started = true;
        }
    }
}
