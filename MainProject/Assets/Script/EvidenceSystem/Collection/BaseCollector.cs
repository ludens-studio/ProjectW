using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 收集器类
/// </summary>
public abstract class BaseCollector : ScriptableObject
{
    [SerializeReference]public BaseEvidence[] evidenceList;
    [SerializeReference]protected AllEvidence mainDic;

   

    /// <summary>
    /// 将证据移除收集器
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
    /// 将证据加入背包
    /// </summary>
    public abstract bool AddEvidence(string evidence);

    /// <summary>
    /// ͨ从收集器中获得名叫objectName的证据
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    public BaseEvidence GetEvidence(string objectName)
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
