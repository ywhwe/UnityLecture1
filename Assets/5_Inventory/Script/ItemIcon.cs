using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerUpHandler, IPointerDownHandler
{
    public Slot slot;
    public Vector2 pos;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetPos()
    {
        rectTransform.anchoredPosition = pos;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        slot.MouseEnter();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        slot.MouseExit();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        slot.MouseMove(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pos = eventData.position;
        slot.MouseDown(this);
    }
}
