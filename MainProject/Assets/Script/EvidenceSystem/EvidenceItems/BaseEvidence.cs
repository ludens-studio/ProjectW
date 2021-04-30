using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvidence : ScriptableObject
{

    [SerializeReference]protected string evidenceName;
    [TextArea]
    [SerializeReference]protected string describe;
    [Header("��ѡ����������Ӧ�����������仯�Ŀ���")]
    [TextArea]
    [SerializeReference] protected List<string> candidateDescribe=new List<string>();

    /// <summary>
    /// ��ȡ֤������
    /// </summary>
    /// <returns></returns>
    public string GetEvidenceName() 
    {
        return evidenceName;
    }
    /// <summary>
    /// ��ȡ֤������
    /// </summary>
    /// <returns></returns>
    public string GetDescribe() 
    {
        return describe;
    }
    /// <summary>
    /// �޸�֤������
    /// </summary>
    /// <param name="desc"></param>
    protected void ChangeDescribe(string desc) 
    {
        describe = desc;
    }
}
