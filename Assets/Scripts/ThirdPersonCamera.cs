using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject player; // Referencia al jugador
    public Vector3 offset = new Vector3(0, 2, -5); // Distancia y altura de la c�mara respecto al jugador
    public float rotationSpeed = 5f; // Velocidad de rotaci�n de la c�mara

    private Vector3 actualOffset; // Offset ajustado seg�n la rotaci�n

    void Start()
    {
        // Inicializa el offset basado en la posici�n inicial de la c�mara
        actualOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("No hay un jugador asignado para la c�mara.");
            return;
        }

        // Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = player.transform.position + actualOffset;

        // Suaviza el movimiento de la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);

        // Haz que la c�mara mire hacia el jugador
        transform.LookAt(player.transform);
    }
}
