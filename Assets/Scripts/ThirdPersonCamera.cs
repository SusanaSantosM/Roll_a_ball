using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject player; // Referencia al jugador
    public Vector3 offset = new Vector3(0, 2, -5); // Distancia y altura de la cámara respecto al jugador
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara

    private Vector3 actualOffset; // Offset ajustado según la rotación

    void Start()
    {
        // Inicializa el offset basado en la posición inicial de la cámara
        actualOffset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("No hay un jugador asignado para la cámara.");
            return;
        }

        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = player.transform.position + actualOffset;

        // Suaviza el movimiento de la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);

        // Haz que la cámara mire hacia el jugador
        transform.LookAt(player.transform);
    }
}
