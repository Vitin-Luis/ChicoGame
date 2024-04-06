using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            transform.Rotate(Vector3.down, -rotationSpeed * Time.deltaTime);
        }

        // Rotação à direita (tecla D)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
