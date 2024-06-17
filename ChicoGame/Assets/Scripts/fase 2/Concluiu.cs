using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            StartCoroutine(WaitAndLoadNextScene());
        }
    }
    
    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(3); // Espera por 3 segundos
        SceneManager.LoadScene("RunFase"); // Troca para a cena desejada
    }
}
