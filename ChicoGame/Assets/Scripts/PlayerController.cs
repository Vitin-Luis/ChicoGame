using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float maxSpeed = 30f;
    public float accelerationRate = 3f;
    public float deaccelerationRate = 5f;
    private float currentSpeed = 0f;
    private float delayR = 5f;
    private float delayL = 5f;

    [SerializeField] private GameObject CBallR;
    [SerializeField] private GameObject CBallL;

    [SerializeField] private GameObject Cannon1R;
    [SerializeField] private GameObject Cannon2R;
    [SerializeField] private GameObject Cannon3R;
    [SerializeField] private GameObject Cannon1L;
    [SerializeField] private GameObject Cannon2L;
    [SerializeField] private GameObject Cannon3L;

     

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
        Instantiate(CBallL, Cannon1L.transform.position, CBallL.transform.rotation);
        Instantiate(CBallL, Cannon2L.transform.position, CBallL.transform.rotation);
        Instantiate(CBallL, Cannon3L.transform.position, CBallL.transform.rotation);
    }
    void ShootRight()
    {
        Instantiate(CBallR, Cannon1R.transform.position, CBallR.transform.rotation);
        Instantiate(CBallR, Cannon2R.transform.position, CBallR.transform.rotation);
        Instantiate(CBallR, Cannon3R.transform.position, CBallR.transform.rotation);
    }
}
