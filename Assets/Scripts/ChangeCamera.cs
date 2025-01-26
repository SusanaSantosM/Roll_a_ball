using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject MainCamera; // Cámara general

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateThirdPersonCamera();
    }

    // Update is called once per frame
    void Update()
    {
        // Vamos a cambiar la camara según las teclas

        // Cámara en primera persona, tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateFirstPersonCamera();
        }
        // Cámara en tercera persona, tecla 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateThirdPersonCamera();
        }
        // Cámara del principal, tecla 3
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
