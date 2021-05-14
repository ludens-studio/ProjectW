using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可被带走的物证
/// </summary>
public abstract class TalkableObject : MonoBehaviour, AddToPackage
{
    [SerializeReference] protected string objectName;

    /// <summary>
    /// 加入背包的具体逻辑
    /// </summary>
    protected abstract void ToPackage();

    /// <summary>
    /// 具体交互形式
    /// </summary>
    public virtual void InteractAction() 
    {
        StartAquire();
        ToPackage();
        EndAquire();
    }

    public abstract void EndAquire();
    public abstract void StartAquire();
}
