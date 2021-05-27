using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnClicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pressed = false;
    
    public void OnPointerDown(PointerEventData e)
    {
        pressed = true;
    }
    
    public void OnPointerUp(PointerEventData e)
    {
        pressed = false;
    }
}
