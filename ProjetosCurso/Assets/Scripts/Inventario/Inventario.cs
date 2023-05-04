using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject inventario;
    public GameObject painelInventario;
    //inventario
    public List<GameObject> itemList = new List<GameObject>();
    //lista de objetos existentes do inventario (preFabricado)
    public List<GameObject> idsItens = new List<GameObject>();
    //lista de objetos existentes da cena (preFabricado)
    public List<GameObject> idsItensCena = new List<GameObject>();
    public List<Button> botoesEjetar = new List<Button>();
    public Transform posicoesEjetar;
    public bool inventarioAberto = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            this.colocarItensInventario();
            this.inventario.SetActive(!this.inventario.activeInHierarchy);
            if (this.inventario.activeInHierarchy) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            this.inventarioAberto = this.inventario.activeInHierarchy;
        }
    }

    private GameObject pegarItemPeloIdItem(string idItem) {
        return idsItens.Find((item) => {
            return item.name == idItem;
        });
    }

     private GameObject pegarItemCenaPeloIdItem(string idItem) {
        return idsItensCena.Find((item) => {
            return item.name == idItem;
        });
    }

    private void colocarItensInventario() {
        Image[] divisas = this.painelInventario.GetComponentsInChildren<Image>();

        for (int i = 1; i < divisas.Length; i++) {
            foreach (Transform child in divisas[i].gameObject.transform) {
                Destroy(child.gameObject);
            }
            this.botoesEjetar[i-1].gameObject.SetActive(false);
        }

        for (int i = 0; i < itemList.Count; i++) {
            GameObject objeto = Instantiate(this.pegarItemPeloIdItem(itemList[i].GetComponent<Item>().idItem), divisas[i+1].gameObject.transform);
            objeto.transform.localScale = new Vector3(150, 150, 150);
            objeto.transform.position = new Vector3(objeto.transform.position.x, objeto.transform.position.y, -1.308885f);
            objeto.transform.rotation = Quaternion.Euler(-25, 25, 0);
            botoesEjetar[i].gameObject.SetActive(true);
        }
    }
    
    public bool AddItem(string idItem) {
        if (itemList.Count < 10) {
            GameObject item = this.pegarItemPeloIdItem(idItem);
            if (item != null) {
                itemList.Add(item);
                this.colocarItensInventario();
                return true;
            }
        }
        return false;
    }

    public void RemoverItem(int posicao) {
        GameObject item = this.pegarItemCenaPeloIdItem(itemList[posicao].GetComponent<Item>().idItem);
        itemList.Remove(itemList[posicao]);
        this.colocarItensInventario();
        GameObject itemInstanciado = Instantiate(item);
        itemInstanciado.transform.position = posicoesEjetar.transform.position;
    }
}
