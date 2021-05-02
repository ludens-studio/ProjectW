using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 注意，所有的道具都没考虑或多次出现在背包中
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/Collection/Package")]
public class Package : BaseCollector
{
    
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
    /// 交换两个物证的位置
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


