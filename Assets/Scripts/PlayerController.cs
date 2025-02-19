using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count = 0;      //El contador inicializa en cero
    private float movementX;
    private float movementY;

    private Vector3 startPosition;

    private Vector3 dir;

    public Transform cameraTransform;  // Referencia a la camara


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //SetCountText(); // Función que cambiara segun la puntuación
        winTextObject.gameObject.SetActive(false);

        dir = Vector3.zero;
    }

    void OnMove(InputValue movementValue) 
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() { 
        countText.text = "Count: " + count.ToString();

        // Vamos a referenciar la variable con el nivel donde estamos
        int nivelActual = SceneManager.GetActiveScene().buildIndex;

        // Condición de puntuación
        if (count > 13) 
        {   
            winTextObject.gameObject.SetActive (true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You win!!";

            // El enmigo se destruye al completar el objetivo
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));

            // Cambiamos al nivel 2
            SceneManager.LoadScene(nivelActual + 1);

        }

    }

    void FixedUpdate()
    {   
        // Dirección de entrada referente a la camara
        Vector3 forward = cameraTransform.forward; // Hacia adelante de la camara
        Vector3 right = cameraTransform.right;  // Hacia la derecha de la camera

        // Debemos asegurar que las direcciones entén en el plano y
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calculamos la dirección del movimiento
        Vector3 movement = forward* movementY + right* movementX;

        // Aplicamos la fuerza del jugador
        rb.AddForce(movement * speed);

        // Movimiento del jugador
        //Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //rb.AddForce(movement * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive (true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que chocó tiene el trigger
        if (other.gameObject.CompareTag("PickUp")) {
            //Desactiva el objeto con que choca. (Lo desaparece)
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }

        Debug.Log("Tocando algo");
        if (other.gameObject.tag == "Cambio" && count == 12)
        {

            Debug.Log("Tocando Cambio");

            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You win!!";
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
}
