using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; 
    public float rotationSpeed = 5f;
    public Vector3 offset = new Vector3(0, 2, -5);

    [SerializeField]

    void Start()
    {
        originalRotation = transform.rotation; 
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) { }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = originalRotation; 
        }
    }
}
