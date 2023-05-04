using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float sensibilidadeMouse = 90f;
    public Transform player;
    private float rotacaoX = 0f;
    private Inventario inventario;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.inventario = GameObject.FindObjectOfType<Inventario>();
    }

    
    void Update()
    {
        if (this.inventario.inventarioAberto) {
            return;
        }
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        this.rotacaoX -= mouseY;
        this.rotacaoX = Mathf.Clamp(this.rotacaoX, -90f, 70f);

        transform.localRotation = Quaternion.Euler(this.rotacaoX, 0f, 0f);
        this.player.Rotate(new Vector3(0, 1, 0) * mouseX);
    }
}
