using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 格子的父类，就是实现接口的
/// </summary>
public abstract class Slot : MonoBehaviour, IDragHandler,IPointerEnterHandler,IPointerExitHandler,IEndDragHandler
{
    [HideInInspector]public bool usable=true;
    [SerializeReference] protected Transform parentSlot;
    public CanvasGroup canvasGroup;
    public int id;

    protected void start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    public abstract void OnDrag(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
    public abstract void OnEndDrag(PointerEventData eventData);
}
