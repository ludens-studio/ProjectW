using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PackageSlot : Slot
{
    [SerializeReference] private Image back;
    [SerializeReference] private Image front;

    private ObjectEvidence evidence;
    
    /// <summary>
    ///设置物证在背包中的状态 
    /// </summary>
    /// <param name="evidence"></param>
    public void SetEvidence(ObjectEvidence evidence) 
    {
        back.sprite = evidence.GetSprite();
        front.sprite = evidence.GetSprite();
        canvasGroup.interactable = true;
    }

    /// <summary>
    /// 返回道具名，用于交互 
    /// </summary>
    /// <returns></returns>
    public string GetEvidenceName() 
    {
        return evidence.GetEvidenceName();
    }

    /// <summary>
    /// 清空物证
    /// </summary>
    public void Clear() 
    {
        evidence = null;
        back = null;
        front = null;
        canvasGroup.interactable = false;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (usable == false) return;
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (usable == false) return;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (usable == false) return;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (usable == false) return;
    }
}
