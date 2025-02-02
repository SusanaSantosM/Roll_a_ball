using UnityEngine;

public class rampa : MonoBehaviour
{
    public GameObject[] puntos;   //Puntos en los que se va a mover la plataforma
    public float platformSpeed = 1.0f;

    private int puntoIndex = 0;

    private void Update()
    {
        MovePlatform();
    }

    void MovePlatform() 
    {
        // Comparamos la distancia del punto 1 al punto 2
        if (Vector3.Distance(transform.position, puntos[puntoIndex].transform.position) <0.1f) 
        {
            puntoIndex++;

            if (puntoIndex >= puntos.Length) 
            {
                puntoIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, puntos[puntoIndex].transform.position, platformSpeed * Time.deltaTime);
    }
    /**
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.transform.SetParent(null);
        }
    }**/
}
