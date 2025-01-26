using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //SetCountText(); // Función que cambiara segun la puntuación
        winTextObject.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() { 
        countText.text = "Count: " + count.ToString();
        // Condición de puntuación
        if (count >= 12) 
        {   
            winTextObject.gameObject.SetActive (true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You win!!";

            // Destroy enemy
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
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
            count = count + 1;

            SetCountText();
        }
    }
}
