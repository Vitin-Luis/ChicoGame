using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsável pelo movimento da câmera
public class CameraMovement : MonoBehaviour
{
    // Referência para a câmera
    [SerializeField] private Camera cam;
    
    // Referência para o alvo da câmera
    [SerializeField] private Transform target;
    
    // Distância entre a câmera e o alvo
    [SerializeField] private float distanceToTarget = 90;

    // Vetor de posição da câmera
    public Vector3 pos;

    // Posição anterior do mouse
    private Vector3 previousPosition;

    // Atualização
    void Update()
    {
        // Quando o botão do mouse é pressionado
        if (Input.GetMouseButtonDown(0))
        {
            // Armazena a posição atual do mouse na viewport
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        // Quando o botão do mouse está sendo segurado
        else if (Input.GetMouseButton(0))
        {
            // Obtém a nova posição do mouse na viewport
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            // Calcula a direção do movimento do mouse
            Vector3 direction = previousPosition - newPosition;

            // Calcula a rotação em torno do eixo Y
            float rotationAroundYAxis = -direction.x * 180;
            // Calcula a rotação em torno do eixo X
            float rotationAroundXAxis = direction.y * 180;

            // Define a posição da câmera como a posição do alvo
            cam.transform.position = target.position;

            // Rotaciona a câmera em torno do eixo X
            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            // Rotaciona a câmera em torno do eixo Y
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            // Move a câmera para trás em relação ao alvo
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            // Atualiza a posição anterior do mouse
            previousPosition = newPosition;
        }
        
        // Mantém a câmera sempre olhando para o alvo
        cam.transform.LookAt(target);
    }
}
