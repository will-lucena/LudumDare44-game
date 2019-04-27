using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSwipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float offsetX;
    private float offsetY;

    private Vector2 originalPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPos.x = transform.position.x;
        originalPos.y = transform.position.y;

        offsetX = transform.position.x - eventData.position.x;
        offsetY = transform.position.y - eventData.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPos = new Vector2(eventData.position.x + offsetX, eventData.position.y + offsetY);
        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragHandler droppedRegion = eventData.pointerCurrentRaycast.gameObject.GetComponent<DragHandler>();

        if (droppedRegion)
        {
            droppedRegion.overEvent?.Invoke();
        }
        transform.position = originalPos;
    }
}
