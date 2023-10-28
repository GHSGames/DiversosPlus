using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform jogador;
    public AnimacaoController animacaoJogador;
    public GameObject cameraAgachado;
    public GameObject cameraEmPe;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        if (this.animacaoJogador.GetAgachado()) {
            this.cameraEmPe.SetActive(false);
            this.cameraAgachado.SetActive(true);
        } else {
            this.cameraEmPe.SetActive(true);
            this.cameraAgachado.SetActive(false);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(xRotation, -90f, 75f);

        this.cameraAgachado.transform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);
        this.cameraEmPe.transform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);

        this.jogador.Rotate(Vector3.up * mouseX);

    }
}
