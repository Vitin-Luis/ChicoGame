using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe responsável pelo controle do jogador
public class PlayerController : MonoBehaviour
{
    // Velocidade atual de rotação
    public float currentRotationSpeed;

    // Velocidade máxima de rotação
    public float maxRotationSpeed = 35;

    // Velocidade máxima de movimento
    public float maxSpeed = 30f;

    // Taxa de aceleração
    public float accelerationRate = 3f;

    // Taxa de desaceleração
    public float deaccelerationRate = 5f;

    // Velocidade atual de movimento
    public float currentSpeed = 0f;

    // Saúde do jogador
    public float health = 100;

    // Atraso para o tiro direito
    private float delayR = 5f;

    // Atraso para o tiro esquerdo
    private float delayL = 5f;

    public GameOverScreen gameOverScreen;

    // Partículas e pontos de fogo para os tiros direito e esquerdo
    [SerializeField] public ParticleSystem[] flashR;
    [SerializeField] public ParticleSystem[] flashL;
    [SerializeField] public GameObject[] firePointsR;
    [SerializeField] public GameObject[] firePointsL;

    // Prefab da bola de fogo
    [SerializeField] private GameObject CBall;

    void Start()
    {
        Time.timeScale = 1f;
    }
    
    // Atualização
    void Update()
    {
        // Obtém as entradas do jogador para aceleração vertical e horizontal
        float inputAccelerationForward = Input.GetAxis("Vertical");
        float inputAccelerationHorizontal = Input.GetAxis("Horizontal");
        
        // Decrementa os atrasos dos tiros
        delayR -= Time.deltaTime;
        delayL -= Time.deltaTime;
        
        // Limita as velocidades de rotação e movimento dentro dos valores máximos
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, -maxRotationSpeed, maxRotationSpeed);

        // Verifica se a saúde do jogador chegou a zero
        if(health <= 0f)
        {
            // Para o Jogo e Mostra tela de Game Over
            GameOver();
        }

        // Acelera o jogador para frente se houver entrada
        if (inputAccelerationForward != 0f)
        {
            currentSpeed += inputAccelerationForward * accelerationRate * Time.deltaTime;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        // Desacelera o jogador se não houver entrada
        else
        {
            currentSpeed -= deaccelerationRate * Time.deltaTime;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        // Rotaciona o jogador se houver entrada horizontal
        if (inputAccelerationHorizontal != 0f)
        {
            currentRotationSpeed += inputAccelerationHorizontal * Time.deltaTime * (accelerationRate + 3);      
            transform.Rotate(Vector3.up * currentRotationSpeed * Time.deltaTime);
        }
        // Desacelera a rotação se não houver entrada
        else
        {
            if (currentRotationSpeed > 0)
            {
                currentRotationSpeed -= (deaccelerationRate + 7) * Time.deltaTime;
                currentRotationSpeed = Mathf.Max(currentRotationSpeed, 0f);
            }
            else if (currentRotationSpeed < 0)
            {
                currentRotationSpeed += (deaccelerationRate + 7) * Time.deltaTime;
                currentRotationSpeed = Mathf.Min(currentRotationSpeed, 0f);
            }
            transform.Rotate(Vector3.up * currentRotationSpeed * Time.deltaTime);
        }
        
        // Verifica se a tecla Q foi pressionada e dispara à esquerda se o atraso permitir
        if (Input.GetKey(KeyCode.Q) && delayL < 0)
        {
            delayL = 5;
            ShootLeft();
        }
        
        // Verifica se a tecla E foi pressionada e dispara à direita se o atraso permitir
        if (Input.GetKey(KeyCode.E) && delayR < 0)
        {
            delayR = 5;
            ShootRight();
        }
    }

    // Função de Game Over
    public void GameOver()
    {
        ScoreManager.scoreCount = 0;
        gameOverScreen.Setup();
    }
    
    // Função para disparar à esquerda
    void ShootLeft()
    {
        for(int i = 0; i<=2;  i++)
        {
            Quaternion initialRotation = firePointsL[i].transform.rotation;
            firePointsL[i].transform.Rotate(0f + (currentSpeed * 0.8f), 0f, 0f, Space.Self);
            Rigidbody C = Instantiate(CBall, firePointsL[i].transform.position, firePointsL[i].transform.rotation).GetComponent<Rigidbody>();
            C.AddRelativeForce(transform.up * 80f, ForceMode.Impulse);
            flashL[i].Play(); 
            firePointsL[i].transform.rotation = initialRotation;
        }
    }

    // Função para disparar à direita
    void ShootRight()
    {
        for(int i = 0; i<=2; i++) 
        {
            Quaternion initialRotation = firePointsR[i].transform.rotation;
            firePointsR[i].transform.Rotate(0f - (currentSpeed * 0.8f), 0f, 0f, Space.Self);
            Rigidbody C = Instantiate(CBall, firePointsR[i].transform.position, firePointsR[i].transform.rotation).GetComponent<Rigidbody>();
            C.AddRelativeForce(transform.up * 80f, ForceMode.Impulse);
            flashR[i].Play();
            firePointsR[i].transform.rotation = initialRotation;
        }
    }

    // Função chamada quando o jogador colide com outro Collider
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o Collider do outro GameObject tem a tag "Bala"
        if (other.gameObject.CompareTag("Bala"))
        {
            // Reduz a saúde do jogador quando atingido por uma bala
            health -= 10;
        }
        if (other.gameObject.CompareTag("Box"))
        {
            // Reduz a saúde do jogador quando atingido por uma bala
            health += 15;
        }
    }
}
