using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvidence : ScriptableObject
{

    [SerializeReference]protected string evidenceName;
    [TextArea]
    [SerializeReference]protected string describe;
    [Header("候选描述，用于应付可能描述变化的可能")]
    [TextArea]
    [SerializeReference] protected List<string> candidateDescribe=new List<string>();

    /// <summary>
    /// 获取证据名字
    /// </summary>
    /// <returns></returns>
    public string GetEvidenceName() 
    {
        return evidenceName;
    }
    /// <summary>
    /// 获取证据描述
    /// </summary>
    /// <returns></returns>
    public string GetDescribe() 
    {
        return describe;
    }
    /// <summary>
    /// 修改证据描述
    /// </summary>
    /// <param name="desc"></param>
    protected void ChangeDescribe(string desc) 
    {
        describe = desc;
    }
}
