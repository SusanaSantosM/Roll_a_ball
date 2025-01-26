using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;         // Referencia al objeto que seguirá la cámara (CameraTarget)
    public float distance = 5f;      // Distancia desde el objetivo
    public float height = 3f;        // Altura de la cámara
    public float rotationSpeed = 5f; // Velocidad de rotación con el mouse

    private float currentYaw = 0f;

    void LateUpdate()
    {
        // Obtener entrada del mouse para rotar alrededor del objetivo
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Acumular la rotación en el eje Y
        currentYaw += mouseX;

        // Calcular la posición de la cámara en relación con el objetivo
        Vector3 desiredPosition = target.position
                                  - Quaternion.Euler(0, currentYaw, 0) * Vector3.forward * distance;
        desiredPosition.y = target.position.y + height;

        // Mover la cámara a la posición deseada
        transform.position = desiredPosition;

        // Hacer que la cámara mire hacia el objetivo
        transform.LookAt(target);
    }
}
