using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 操作背包UI 的动画行为
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
        //初始化变量
        antor = gameObject.GetComponent<Animator>();
        slots = GetComponentsInChildren<PackageSlot>();
        eviMgr = EvidenceManager.GetInstance();
        package = eviMgr.package;

        //初始化UI
        ResetPackage();

        //订阅添加删除物品事件
        eviMgr.AddObjectEvent += new EvidenceManager.EvidenceHandler(AddEvidence);
        eviMgr.RemoveObjectEvent += new EvidenceManager.EvidenceHandler(RemoveEvidence);

    }

    /// <summary>
    /// 开关面板动画而已
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
    /// UI行为，将证据加入特定格中
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
    /// 将物品从背包UI移除
    /// </summary>
    /// <param name="eviname"></param>
    private void RemoveEvidence(string eviname) 
    {
        foreach (PackageSlot slot in slots)
        {
            if (slot.GetEvidenceName().Equals(eviname))
            {
                slot.Clear();
                slot.usable = true;
                return;
            }
        }
        Debug.LogError(new System.Exception("No More Such Item"));
    }

    /// <summary>
    /// 在加载场景时保存背包结构
    /// </summary>
    private void ResetPackage() 
    {
        for (int i = 0; i < 12; i++) 
        {
            if (package.evidenceList[i] != null) slots[i].SetEvidence((ObjectEvidence)package.evidenceList[i]);   
        }
    }

    private void OnDestroy()
    {
        //取消订阅事件，避免报错
        eviMgr.AddObjectEvent -= new EvidenceManager.EvidenceHandler(AddEvidence);
        eviMgr.RemoveObjectEvent -= new EvidenceManager.EvidenceHandler(RemoveEvidence);
    }

}
