using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarFase : MonoBehaviour
{

    [SerializeField] public HealthBar HealthBar;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar.slider.value <= 0)
        {
            StartCoroutine(WaitAndLoadNextScene());        
        }
    }
    
    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(3); // Espera por 3 segundos
        SceneManager.LoadScene("FASE2"); // Troca para a cena desejada
    }
    
}
