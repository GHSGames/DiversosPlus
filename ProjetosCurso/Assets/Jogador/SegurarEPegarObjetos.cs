using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurarEPegarObjetos : MonoBehaviour
{
    public ButtonScript botaoA;
    public ButtonScript botaoB;
    public float distanciaMaxima = 2.0f;
    public LayerMask layer;
    public List<string> tagsObjetosSeguraveis;
    public List<string> tagsObjetosPegaveis;
    public List<Transform> posicoesMao;
    private bool segurando = false;
    private Transform objeto;
    private bool trava = false;

    void Update()
    {
        if (!this.botaoA.presionando && !this.trava) {
            segurando = false;
        }

        if (segurando) {
            if (this.botaoB.presionando) {
                segurando = false;
                this.trava = false;
            }
            int index = 0;
            objeto.position = posicoesMao[index].position;
            objeto.rotation = posicoesMao[index].rotation;
        } else {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaMaxima, layer, QueryTriggerInteraction.Ignore)) {
                if (this.botaoA.presionando) {
                    string tagObjeto = tagsObjetosPegaveis.Find((tag) => {
                        if (hit.transform.gameObject.tag == tag) {
                            return true;
                        } else {
                            return false;
                        }
                    });

                    if (tagObjeto != null) {
                        segurando = true;
                        objeto = hit.transform;
                    }
                } else if (this.botaoB.presionando) {
                    this.trava = true;
                    string tagObjeto = tagsObjetosSeguraveis.Find((tag) => {
                        if (hit.transform.gameObject.tag == tag) {
                            return true;
                        } else {
                            return false;
                        }
                    });

                    if (tagObjeto != null) {
                        segurando = true;
                        objeto = hit.transform;
                    }
                }
            }
        }
    }
}
