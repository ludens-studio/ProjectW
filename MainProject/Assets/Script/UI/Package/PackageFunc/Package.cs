using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ע�⣬���еĵ��߶�û���ǻ��γ����ڱ�����
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/Collection/Package")]
public class Package : BaseCollector
{
    
    public override void AddEvidence(string evidence)
    {
        ObjectEvidence objE = mainDic.GetObjectEvidence(evidence);
        for (int i = 0; i < 12; i++)
        {
            if (evidenceList[i] == null)
            {
                evidenceList[i] = objE;
                break;
            }
        }
    }

}


