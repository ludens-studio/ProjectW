using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������UI �Ķ�����Ϊ
/// </summary>
public class PackageUI : MonoBehaviour
{
    private Animator antor;
    private bool isHide = true;
    private EvidenceManager eviMgr;
    private Package package;
    [SerializeReference] private PackageSlot[] slots;

    private void Awake()
    {
        //��ʼ������
        antor = gameObject.GetComponent<Animator>();
        slots = GetComponentsInChildren<PackageSlot>();
        eviMgr = EvidenceManager.GetInstance();
        package = eviMgr.package;

        //��ʼ��UI
        ResetPackage();

        //��������ɾ����Ʒ�¼�
        eviMgr.AddObjectEvent += new EvidenceManager.EvidenceHandler(AddEvidence);
        eviMgr.RemoveObjectEvent += new EvidenceManager.EvidenceHandler(RemoveEvidence);

    }

    /// <summary>
    /// ������嶯������
    /// </summary>
    public void ShowPanel()
    {
        if (isHide)
        {
            isHide = false;
            antor.Play("Show");
        }
        else
        {
            isHide = true;
            antor.Play("Hide");
        }
    }

    /// <summary>
    /// UI��Ϊ����֤�ݼ����ض�����
    /// </summary>
    private void AddEvidence(string eviname)
    {
        foreach (PackageSlot slot in slots)
        {
            if (slot.usable == true)
            {
                ObjectEvidence evi = eviMgr.allEvidences.GetObjectEvidence(eviname);
                slot.SetEvidence(evi);
                slot.usable = false;
                return;
            }
        }
        Debug.LogError(new System.Exception("No More Empty Slot"));
    }

    /// <summary>
    /// ����Ʒ�ӱ���UI�Ƴ�
    /// </summary>
    /// <param name="eviname"></param>
    private void RemoveEvidence(string eviname) 
    {
        foreach (PackageSlot slot in slots)
        {
            if (slot.GetEvidenceName().Equals(eviname))
            {
                slot.Clear();
                return;
            }
        }
        Debug.LogError(new System.Exception("No More Such Item"));
    }

    /// <summary>
    /// �ڼ��س���ʱ���汳���ṹ
    /// </summary>
    private void ResetPackage() 
    {
        for (int i = 0; i < 12; i++) 
        {
            slots[i].id = i;
            if (package.evidenceList[i] != null) slots[i].SetEvidence((ObjectEvidence)package.evidenceList[i]);   
        }
    }

    private void OnDestroy()
    {
        //ȡ�������¼������ⱨ��
        eviMgr.AddObjectEvent -= new EvidenceManager.EvidenceHandler(AddEvidence);
        eviMgr.RemoveObjectEvent -= new EvidenceManager.EvidenceHandler(RemoveEvidence);
    }

}
