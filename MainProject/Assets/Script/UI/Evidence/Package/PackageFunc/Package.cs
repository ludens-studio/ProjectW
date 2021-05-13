using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包，用于收集物证
/// </summary>
public class Package : BaseCollector
{
    /// <summary>
    /// 添加物证
    /// </summary>
    /// <param name="evidence"></param>
    /// <returns></returns>
    public override bool AddEvidence(string evidence)
    {
        ObjectEvidence objE = mainDic.GetObjectEvidence(evidence);
        for (int i = 0; i < 12; i++)
        {
            if (evidenceList[i] == null)
            {
                evidenceList[i] = objE;
                break;
            }
            else if (evidenceList[i].GetEvidenceName().Equals(evidence))return false;
        }
        return true;
    }

    /// <summary>
    /// 交换物证位置
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void SwitchEvidence(int a, int b) 
    {
        ObjectEvidence tem = (ObjectEvidence)evidenceList[a];
        evidenceList[a] = evidenceList[b];
        evidenceList[b] = tem;
    }
    
}


