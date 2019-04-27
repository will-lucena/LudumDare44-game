using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public System.Action overEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        Debug.Log(eventData.pointerPress);
        //overEvent?.Invoke();
    }
}
