using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    public float dano = 10f;

    public float range = 100f;
    public Camera fpsCam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Inimigo inimigo = hit.transform.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.TomarDano(dano);
            }
        }
    }
    
}
