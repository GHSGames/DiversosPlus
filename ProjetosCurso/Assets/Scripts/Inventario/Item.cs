using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string idItem;

    private void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "Player") {
            Jogador jogador = c.gameObject.GetComponent<Jogador>();
            bool adicionou = jogador.inventario.AddItem(idItem);
            if (adicionou) {
                Destroy(gameObject);
            }
        }
    }
}
