using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class accion : MonoBehaviour,IPointerDownHandler,
    IPointerUpHandler
{
    public bool ispressed = false;

    public void OnPointerDown(PointerEventData eventData)
    // Use this for initialization
    {
        ispressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
	
		

}
