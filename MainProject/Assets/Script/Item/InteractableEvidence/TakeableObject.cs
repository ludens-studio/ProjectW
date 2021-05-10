using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可交互类,抽象类
/// </summary>
public abstract class TalkableObject : MonoBehaviour, AddToPackage
{
    [SerializeReference] private string objectName;
    [SerializeReference] private bool isObject;

    /// <summary>
    /// 加入背包接口
    /// </summary>
    protected void ToPackage()
    {
        EndAquire();
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        if (isObject) eviMGR.AddObjectEvidence(objectName);
        else eviMGR.AddWordEvidence(objectName);
    }

    /// <summary>
    /// 交互模式，玩家怎么样把物品加入背包
    /// </summary>
    protected void InteractAction() 
    {
        StartAquire();
        ToPackage();
        EndAquire();
    }

    public abstract void EndAquire();
    public abstract void StartAquire();
}
