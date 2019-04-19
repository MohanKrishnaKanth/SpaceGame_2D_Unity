using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class joystick : MonoBehaviour , IPointerDownHandler, IPointerUpHandler , IDragHandler 
  
{
        private Image jsContainer;
        private Image joystickk;
        public bool pressed;
        public Vector3 InputDirection;

        void Start()
        {

            jsContainer = GetComponent<Image>();
            joystickk = GameObject.Find("Handle").GetComponent<Image>(); //this command is used because there is only one child in hierarchy
            InputDirection = Vector3.zero;
        }

        public  void OnDrag(PointerEventData ped)
        {
             
            Vector2 position = Vector2.zero;
            pressed = true;
            //To get InputDirection
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                    (jsContainer.rectTransform,
                    ped.position,
                    ped.pressEventCamera,
                    out position);

            position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
            position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

            float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1/2 : position.x * 2 - 1/2;
            float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1/2 : position.y * 2 - 1/2;

            InputDirection = new Vector3(x, y,0);
            InputDirection = (InputDirection.magnitude > 0.6) ? InputDirection.normalized : InputDirection*1.5f;

            //to define the area in which joystick can move around
            joystickk.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3)
                                                                   , InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);

        }

        public void OnPointerDown(PointerEventData ped)
        {
        OnDrag(ped);
            
        }

    

      

        public void OnPointerUp(PointerEventData ped)
        {
            pressed=false;
            InputDirection = Vector3.zero;
            joystickk.rectTransform.anchoredPosition = Vector3.zero;
        }
    
}
