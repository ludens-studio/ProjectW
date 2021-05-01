using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可交互类,抽象类
/// </summary>
public abstract class InteractableObj : MonoBehaviour
{
    [SerializeReference] private string objectName;
    [SerializeReference] private bool isObject;


    protected void Awake()
    {
    }

    /// <summary>
    /// 加入背包接口
    /// </summary>
    protected void ToPackage()
    {
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        if (isObject) eviMGR.AddObjectEvidence(objectName);
        else eviMGR.AddWordEvidence(objectName);
    }

    /// <summary>
    /// 交互模式，即玩家如何与物品交互
    /// </summary>
    protected abstract void InteractAction();
}
