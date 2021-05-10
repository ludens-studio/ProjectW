using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象类，可带走的证据（物证），挂载，加入了加入背包接口
/// </summary>
public abstract class TalkableObject : MonoBehaviour, AddToPackage
{
    [SerializeReference] private string objectName;
    [SerializeReference] private bool isObject;

    /// <summary>
    /// 将物品加入到背包，但是并不会销毁物品
    /// </summary>
    protected void ToPackage()
    {
        EndAquire();
        EvidenceManager eviMGR = EvidenceManager.GetInstance();
        if (isObject) eviMGR.AddObjectEvidence(objectName);
        else eviMGR.AddWordEvidence(objectName);
    }

    /// <summary>
    /// 具体的加入背包的行为
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
