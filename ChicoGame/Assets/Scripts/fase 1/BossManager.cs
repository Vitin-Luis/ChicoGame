using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int health;
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        health = 300;   
    }

    // Update is called once per frame
    void Update()
    {   
        transform.LookAt(Player.transform.position);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bala"))
        {
            health -= 10;
        }
    }
}
