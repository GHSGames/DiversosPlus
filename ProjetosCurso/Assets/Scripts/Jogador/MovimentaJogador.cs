using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaJogador : MonoBehaviour
{
    public float velocidade = 5;
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * this.velocidade * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * this.velocidade * Time.deltaTime;
        transform.Translate(new Vector3(horizontal, 0, vertical));
    }
}
