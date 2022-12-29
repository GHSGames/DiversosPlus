using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float rotacao = 90.0f;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        this.rotacionarCamera();
    }

    private void rotacionarCamera() {
        float rotacaoX = transform.rotation.eulerAngles.x;
        bool travaDecida = false;
        bool travaSubida = false;
        bool movimenta = true;
        float mouseY = Input.GetAxis("Mouse Y");

        if (rotacaoX >= 0 && rotacaoX <= 90) {
            if (mouseY * -1 + rotacaoX >= 75) {
                travaDecida = true;
                transform.rotation = Quaternion.Euler(75, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
        }

        if (rotacaoX >= 270 && rotacaoX <= 360) {
            if (mouseY * -1 + rotacaoX <= 280) {
                travaSubida = true;
                transform.rotation = Quaternion.Euler(280, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
        }

        if (mouseY < 0 && travaDecida) {
            movimenta = false;
        }

        if (mouseY > 0 && travaSubida) {
            movimenta = false;
        }

        if (movimenta) {
            transform.Rotate(new Vector3(mouseY * this.rotacao * Time.deltaTime * -1, 0, 0));
        }

    }
}
