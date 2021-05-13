using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 收集器类，抽象类
/// </summary>
public abstract class BaseCollector : ScriptableObject
{
    public BaseEvidence[] evidenceList;
    [SerializeReference]protected AllEvidence mainDic;

   

    /// <summary>
    /// 将某个证据移除
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
    /// 将某个证据加入收集器
    /// </summary>
    public abstract bool AddEvidence(string evidence);

    /// <summary>
    /// ͨ获取某个证据
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    public ObjectEvidence GetEvidence(string objectName)
    {
        BaseEvidence tem=SearchEvidence(objectName);
        if(tem!=null) return (ObjectEvidence) tem;
        else return null;
    }

    private BaseEvidence SearchEvidence(string objectName) 
    {
        foreach (BaseEvidence evidence in evidenceList) 
        {
            if(evidence==null) return null;
            if (evidence.GetEvidenceName().Equals(objectName)) return evidence;
        }

        return null;
    }
}
