using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PackageSlot : Slot
{
    [SerializeReference] private Image back;
    [SerializeReference] private Image front;

    private ObjectEvidence evidence;
    
    /// <summary>
    ///������֤�ڱ����е�״̬ 
    /// </summary>
    /// <param name="evidence"></param>
    public void SetEvidence(ObjectEvidence evidence) 
    {
        back.sprite = evidence.GetSprite();
        front.sprite = evidence.GetSprite();
        canvasGroup.interactable = true;
    }

    /// <summary>
    /// ���ص����������ڽ��� 
    /// </summary>
    /// <returns></returns>
    public string GetEvidenceName() 
    {
        return evidence.GetEvidenceName();
    }

    /// <summary>
    /// �����֤
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
