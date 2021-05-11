using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可被带走的物证
/// </summary>
public abstract class TalkableObject : MonoBehaviour, AddToPackage
{
    [SerializeReference] private string objectName;
    [SerializeReference] private bool isObject;

    /// <summary>
    /// 加入背包的具体逻辑
    /// </summary>
    protected void ToPackage()
    {
        EndAquire();
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        if (isObject) eviMGR.AddObjectEvidence(objectName);
        else eviMGR.AddWordEvidence(objectName);
    }

    /// <summary>
    /// 具体交互形式
    /// </summary>
    protected virtual void InteractAction() 
    {
        StartAquire();
        ToPackage();
        EndAquire();
    }

    public abstract void EndAquire();
    public abstract void StartAquire();
}
