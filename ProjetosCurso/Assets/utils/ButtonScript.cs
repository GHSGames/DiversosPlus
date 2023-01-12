using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool presionando = false;
    
    void IPointerDownHandler.OnPointerDown(PointerEventData a) {
        this.presionando = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData a) {
        this.presionando = false;
    }
}
