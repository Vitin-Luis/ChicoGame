using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 90;
    public Vector3 pos;

    private Vector3 previousPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180;
            float rotationAroundXAxis = direction.y * 180;

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
        cam.transform.LookAt(target);
>>>>>>> lucasbackup2
    }
}
