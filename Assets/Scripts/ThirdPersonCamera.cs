using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;         // Referencia al objeto que seguir� la c�mara (CameraTarget)
    public float distance = 5f;      // Distancia desde el objetivo
    public float height = 3f;        // Altura de la c�mara
    public float rotationSpeed = 5f; // Velocidad de rotaci�n con el mouse

    private float currentYaw = 0f;

    void LateUpdate()
    {
        // Obtener entrada del mouse para rotar alrededor del objetivo
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Acumular la rotaci�n en el eje Y
        currentYaw += mouseX;

        // Calcular la posici�n de la c�mara en relaci�n con el objetivo
        Vector3 desiredPosition = target.position
                                  - Quaternion.Euler(0, currentYaw, 0) * Vector3.forward * distance;
        desiredPosition.y = target.position.y + height;

        // Mover la c�mara a la posici�n deseada
        transform.position = desiredPosition;

        // Hacer que la c�mara mire hacia el objetivo
        transform.LookAt(target);
    }
}
