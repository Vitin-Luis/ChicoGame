using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concluiu : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            gameObject.SetActive(false);
            //loadscene
        }
    }
}
