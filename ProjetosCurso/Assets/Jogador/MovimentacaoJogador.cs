using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    public FixedJoystick joystickEsquerdo;
    public FixedJoystick joystickDireito;
    public float velocidade = 10.0f;
    public float rotacao = 90.0f;

    void Update()
    {
        this.Mover();
    }

    private void Mover() {
        float horizontal = joystickEsquerdo.Horizontal;
        float vertical = joystickEsquerdo.Vertical;
        float mouseX = joystickDireito.Horizontal;
        transform.Translate(new Vector3(horizontal * this.velocidade * Time.deltaTime, 0, vertical * this.velocidade * Time.deltaTime));
        transform.Rotate(new Vector3(0, mouseX * this.rotacao * Time.deltaTime, 0));
    }
}
