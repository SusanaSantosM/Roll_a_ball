using TMPro;
using UnityEngine;

public class FirstCam : MonoBehaviour
{
    // Objecto que vamos a segir con la camara
    public GameObject player;
    // Sensibilidad del raton
    public float mouseSensitivity = 100f;
    // valor acumulativo de rotacion en el eje y
    private float yRotation = 0f;

    
    void Start()
    {   // Orientacion de la camara
        Vector3 initialRotation = Vector3.zero;
        transform.rotation = Quaternion.Euler(initialRotation);

        // Establecemos la rtoación horizantal del inicio
        yRotation = initialRotation.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Obtiene los movimientos del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Gira la cámara en el eje horizontal
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        
        // Mantiene el desplazamiento de la cámara y el jugador en todo el juego.
        transform.position = player.transform.position;
    }
}
