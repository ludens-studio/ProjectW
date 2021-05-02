using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 格子的父类，就是实现接口的
/// </summary>
public abstract class Slot : MonoBehaviour, IDragHandler,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    [HideInInspector]public bool usable=true;
    [SerializeReference] protected Transform parentSlot;
    public CanvasGroup canvasGroup;

    protected void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    public abstract void OnDrag(PointerEventData eventData);
    public abstract void OnDrop(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
}
