using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float maxSpeed = 30f;
    public float accelerationRate = 3f;
    public float deaccelerationRate = 5f;
    public float currentSpeed = 0f;
    private float delayR = 5f;
    private float delayL = 5f;
    public ParticleSystem flash;
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

        // Rotação à esquerda (tecla A)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Rotação à direita (tecla D)
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

    }
    void ShootLeft()
    {
        foreach(GameObject fp in firePointsL)
        {
            Quaternion initialRotation = fp.transform.rotation;
            fp.transform.Rotate(0f + currentSpeed, 0f, 0f, Space.Self);
            GameObject C = Instantiate(CBall, fp.transform.position, fp.transform.rotation);
            flash.Play();
            fp.transform.rotation = initialRotation;
        }
    }
    void ShootRight()
    {
        foreach (GameObject fp in firePointsR)
        {
            Quaternion initialRotation = fp.transform.rotation;
            fp.transform.Rotate(0f + currentSpeed, 0f, 0f, Space.Self);
            GameObject C = Instantiate(CBall, fp.transform.position, fp.transform.rotation);
            flash.Play();
            fp.transform.rotation = initialRotation;
        }
    }
}