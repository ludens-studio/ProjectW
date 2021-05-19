using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PackageSlot : Slot, IPointerDownHandler
{
    [SerializeReference] private Image back;
    [SerializeReference] private Image front;
    [SerializeReference] private Image background;

    private static Color emp=new Color(30f,30f,30f,100f);

    private bool isTool=false;
    private ObjectEvidence evidence;
    

    /// <summary>
    ///������֤�ڱ����е�״̬ 
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
        //��ǰ�������ڵ�λ��

        GameObject raycastTarget=null;
        string rayTargetName = "";

        if (eventData.pointerCurrentRaycast.gameObject != null) 
        {
            raycastTarget = eventData.pointerCurrentRaycast.gameObject;
            rayTargetName = raycastTarget.name;
        }       
         else ReturnSlot();


        if (evidence.Interactable(rayTargetName)) 
        raycastTarget.GetComponent<EvidenceInteractor>().Interact(evidence.GetEvidenceName());
        

        if (rayTargetName.Equals("Front")) 
        {
            SwitchSlot(eventData.pointerCurrentRaycast.gameObject.GetComponent<PackageSlot>());
        }
        else ReturnSlot();
    }

    public  void OnPointerDown(PointerEventData eventData)
    {
        if(usable) return;
        SwitchSelection();
    }

    /// <summary>
    /// ����֮ǰ�ĸ���
    /// </summary>
    private void ReturnSlot() 
    {
        front.transform.SetParent(parentSlot);
        front.transform.position = back.transform.position;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// ��������֮�������
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

    public void SwitchSelection()
    {
        if(isTool)
        {
            background.color=Color.white;
            isTool=false;
            ToolMGR.GetInstance().CancleTool(evidence.GetEvidenceName());
        }
        else
        {
            isTool=true;
            background.color=emp;
            ToolMGR.GetInstance().SelectTool(this);
        }
    }
}
