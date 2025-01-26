using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject MainCamera; // C�mara general

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateThirdPersonCamera();
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos a cambiar la camara seg�n las teclas

        // C�mara en primera persona, tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateFirstPersonCamera();
        }
        // C�mara en tercera persona, tecla 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateThirdPersonCamera();
        }
        // C�mara del principal, tecla 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateMainCamera();
        }
    }

    private void ActivateFirstPersonCamera() 
    {
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
        MainCamera.SetActive(false);
    }

    private void ActivateThirdPersonCamera() 
    {
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        MainCamera.SetActive(false);
    }

    private void ActivateMainCamera()
    {
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(false);
        MainCamera.SetActive(true);
    }
}
