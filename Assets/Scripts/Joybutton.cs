using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joybutton : MonoBehaviour , IPointerUpHandler ,IPointerDownHandler {

    public bool pressed;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
