using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    public float velocidade = 10.0f;
    public float rotacao = 90.0f;

    void Update()
    {
        this.Mover();
    }

    private void Mover() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        transform.Translate(new Vector3(horizontal * this.velocidade * Time.deltaTime, 0, vertical * this.velocidade * Time.deltaTime));
        transform.Rotate(new Vector3(0, mouseX * this.rotacao * Time.deltaTime, 0));
    }
}
