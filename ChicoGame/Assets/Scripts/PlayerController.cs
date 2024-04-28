using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float currentRotationSpeed;
    public float maxRotationSpeed = 35;
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
        float inputAccelerationForward = Input.GetAxis("Vertical");
        float inputAccelerationHorizontal = Input.GetAxis("Horizontal");
        delayR -= Time.deltaTime;
        delayL -= Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, -maxRotationSpeed, maxRotationSpeed);

        if (inputAccelerationForward != 0f)
        {
            currentSpeed += inputAccelerationForward * accelerationRate * Time.deltaTime;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed -= deaccelerationRate * Time.deltaTime;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        if (inputAccelerationHorizontal != 0f)
        {
            currentRotationSpeed += inputAccelerationHorizontal * Time.deltaTime * (accelerationRate + 4);      
            transform.Rotate(Vector3.up * currentRotationSpeed * Time.deltaTime);
        }
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
        for(int i = 0; i<=2;  i++)
        {
            Quaternion initialRotation = firePointsL[i].transform.rotation;
            firePointsL[i].transform.Rotate(0f + currentSpeed, 0f, 0f, Space.Self);
            Rigidbody C = Instantiate(CBall, firePointsL[i].transform.position, firePointsL[i].transform.rotation).GetComponent<Rigidbody>();
            C.AddRelativeForce(transform.up * 50f, ForceMode.Impulse);
            flashL[i].Play(); 
            firePointsL[i].transform.rotation = initialRotation;
        }
    }
    void ShootRight()
    {
        for(int i = 0; i<=2; i++) 
        {
            Quaternion initialRotation = firePointsR[i].transform.rotation;
            firePointsR[i].transform.Rotate(0f - currentSpeed, 0f, 0f, Space.Self);
            Rigidbody C = Instantiate(CBall, firePointsR[i].transform.position, firePointsR[i].transform.rotation).GetComponent<Rigidbody>();
            C.AddRelativeForce(transform.up * 50f, ForceMode.Impulse);
            flashR[i].Play();
            firePointsR[i].transform.rotation = initialRotation;
        }
    }
}