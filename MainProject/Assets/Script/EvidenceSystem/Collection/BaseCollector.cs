using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ռ����࣬���󴢴�ϵͳ�ĸ���
/// </summary>
public abstract class BaseCollector : ScriptableObject
{
    [SerializeReference]public BaseEvidence[] evidenceList;
    [SerializeReference]protected AllEvidence mainDic;

   

    /// <summary>
    /// ��֤�ݴ��ռ������Ƴ�
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
    /// ���ռ��������֤�ݣ������Ƿ�ɹ�����
    /// </summary>
    public abstract bool AddEvidence(string evidence);

    /// <summary>
    /// ͨ�����ֻ���ռ�������Ʒ
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
