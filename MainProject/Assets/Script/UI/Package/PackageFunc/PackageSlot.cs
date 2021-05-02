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
        usable = false;
        canvasGroup.blocksRaycasts = true;
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
        if (usable) return;
        front.transform.localScale = new Vector3(1f, 1f, 1f);
        front.transform.SetParent(EvidenceManager.GetInstance().transform);
        front.transform.position = Input.mousePosition;
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (usable) return;
        canvasGroup.blocksRaycasts = false;
        front.transform.SetParent(parentSlot);
        front.transform.position = back.transform.position;
        canvasGroup.blocksRaycasts = true;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (usable) return;
        front.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (usable) return;
        front.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
