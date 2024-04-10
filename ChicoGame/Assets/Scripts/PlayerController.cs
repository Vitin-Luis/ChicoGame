using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    public float moveSpeed = 20f;
    public float rotationSpeed = 30f;

    void Update()
    {
        // Movimento para frente (tecla W)
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Rotação à esquerda (tecla A)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Rotação à direita (tecla D)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
=======
    public float rotationSpeed = 30f;
    public float maxSpeed = 30f;
    public float accelerationRate = 3f;
    public float deaccelerationRate = 5f;
    public float currentSpeed = 0f;
    private float delayR = 5f;
    private float delayL = 5f;
    [SerializeField] public ParticleSystem[] flashR;
    [SerializeField] public ParticleSystem[] flashL;
    [SerializeField] public GameObject[] firePointsR;
    [SerializeField] public GameObject[] firePointsL;

    [SerializeField] private GameObject CBall;

    void Update()
    {
        float inputAcceleration = Input.GetAxis("Vertical");
        delayR -= Time.deltaTime;
        delayL -= Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        if (inputAcceleration != 0f)
        {
            currentSpeed += inputAcceleration * accelerationRate * Time.deltaTime;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed -= deaccelerationRate * Time.deltaTime;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        // RotaÃ§Ã£o Ã  esquerda (tecla A)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // RotaÃ§Ã£o Ã  direita (tecla D)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q) && delayL < 0)
        {
            delayL = 5;
            ShootLeft();
        }
        if (Input.GetKey(KeyCode.E) && delayR < 0)
        {
            delayR = 5;
            ShootRight();
        }

>>>>>>> lucasbackup2
    }
    void ShootLeft()
    {
        for(int i = 0; i<=2;  i++)
        {
            Quaternion initialRotation = firePointsL[i].transform.rotation;
            firePointsL[i].transform.Rotate(0f + currentSpeed, 0f, 0f, Space.Self);
            GameObject C = Instantiate(CBall, firePointsL[i].transform.position, firePointsL[i].transform.rotation);
            flashL[i].Play(); 
            firePointsL[i].transform.rotation = initialRotation;
        }
    }
    void ShootRight()
    {
        for(int i = 0; i<=2; i++) 
        {
            Quaternion initialRotation = firePointsR[i].transform.rotation;
            firePointsR[i].transform.Rotate(0f + currentSpeed, 0f, 0f, Space.Self);
            GameObject C = Instantiate(CBall, firePointsR[i].transform.position, firePointsR[i].transform.rotation);
            flashR[i].Play();
            firePointsR[i].transform.rotation = initialRotation;
        }
    }
}