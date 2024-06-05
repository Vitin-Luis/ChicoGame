using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float vida = 50f;
    // Start is called before the first frame update
    public void TomarDano(float quantidade)
    {
        vida -= quantidade;
        if (vida <= 0f)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
