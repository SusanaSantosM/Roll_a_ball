using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool contactRamp = true;  //Este es el Estado de la rampa que activa o desactiva
    public float fuerza = 10f;       //Fuerza de salto
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!contactRamp) return;  // Si no hay contacto, no hace nada

        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Ajustamos la direccion del salto
                Vector3 direccionImpulso = transform.up + transform.forward;
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(direccionImpulso * fuerza, ForceMode.Impulse);
            }

        }
        
    }

    public void ActivaRampa(bool estado) 
    {
        contactRamp = estado;
        if (animator != null) 
        {
            animator.SetBool("Activada", estado);
        }
    }
}
