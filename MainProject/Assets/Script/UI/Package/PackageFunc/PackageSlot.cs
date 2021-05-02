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
        this.evidence = evidence;
        back.sprite = evidence.GetSprite();
        front.sprite = evidence.GetSprite();
        usable = false;
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
        back.sprite = null;
        front.sprite = null;
        ReturnSlot();
        usable = true;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (usable) return;
        canvasGroup.blocksRaycasts = false;
        front.transform.localScale = new Vector3(1f, 1f, 1f);
        front.transform.SetParent(EvidenceManager.GetInstance().transform);
        front.transform.position = Input.mousePosition;
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

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (usable) return;
        //当前射线所在的位置

        string rayTarget = eventData.pointerCurrentRaycast.gameObject.name;
        if (evidence.Interact(rayTarget)) return;
        else if (rayTarget.Equals("Front")) 
        {
            SwitchSlot(eventData.pointerCurrentRaycast.gameObject.GetComponent<PackageSlot>());        
        }
        else ReturnSlot();
    }

    /// <summary>
    /// 返回之前的格子
    /// </summary>
    private void ReturnSlot() 
    {
        front.transform.SetParent(parentSlot);
        front.transform.position = back.transform.position;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 交换格子之间的内容
    /// </summary>
    /// <param name="slot"></param>
    private void SwitchSlot(PackageSlot slot) 
    {
        ObjectEvidence tem = slot.evidence;
        int other = slot.id;
        if (other== id) return;
        slot.SetEvidence(evidence);
        if (tem == null) Clear();
        else SetEvidence(tem);
        EvidenceManager.GetInstance().package.SwitchEvidence(other,id);
        ReturnSlot();
    }

}
