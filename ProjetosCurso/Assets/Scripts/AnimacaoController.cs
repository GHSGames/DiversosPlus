using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoController : MonoBehaviour
{
    public Animator idle;
    private bool agachado = false;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyUp(KeyCode.LeftControl)) {
            this.agachado = !this.agachado;
        }

        this.definirAnimacoes(horizontal, vertical);
    }

    private void definirAnimacoes(float horizontal, float vertical) {
        this.zerarAnimacoes();

        if (this.agachado) {
            this.idle.SetBool("agachado", true);
        }

        if (vertical > 0) {
            this.idle.SetBool("ir_frente", true);
        } else if (vertical < 0) {
            this.idle.SetBool("ir_tras", true);
        } else {
            if (horizontal != 0) {
                if (horizontal > 0) {
                    this.idle.SetBool("ir_direita", true);
                } else {
                    this.idle.SetBool("ir_esquerda", true);
                }
            }
        }
    }

    private void zerarAnimacoes() {
        this.idle.SetBool("ir_frente", false);
        this.idle.SetBool("ir_tras", false);
        this.idle.SetBool("ir_direita", false);
        this.idle.SetBool("ir_esquerda", false);
        this.idle.SetBool("agachado", false);
    }

    public bool GetAgachado() {
        return this.agachado;
    }
}
