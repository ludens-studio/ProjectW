using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 收集器类，两大储存系统的父类
/// </summary>
public abstract class BaseCollector : ScriptableObject
{
    [SerializeReference] public BaseEvidence[] evidenceList;
    [SerializeReference]protected AllEvidence mainDic;

   

    /// <summary>
    /// 将证据从收集器中移除
    /// </summary>
    /// <param name="objectName"></param>
    public void RemoveEvidence(string objectName)
    {
        for (int i=0;i<12;i++)
        {
            if (evidenceList[i].GetEvidenceName().Equals(objectName))
            {
                evidenceList[i] = null;
                break;
            }   
        }
    }

    /// <summary>
    /// 向收集器中添加证据
    /// </summary>
    public abstract void AddEvidence(string evidence);

    /// <summary>
    /// 通过名字获得收集器中物品
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    protected BaseEvidence GetEvidence(string objectName)
    {
        return SearchEvidence(objectName);
    }

    private BaseEvidence SearchEvidence(string objectName) 
    {
        foreach (BaseEvidence evidence in evidenceList) 
        {
            if (evidence.GetEvidenceName().Equals(objectName)) return evidence;
        }

        return null;
    }
}
