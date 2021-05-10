using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEvidence : ScriptableObject
{

    [SerializeReference]protected string evidenceName;
    [TextArea]
    [SerializeReference]protected string describe;
    [Header("备选描述，用于更改")]
    [TextArea]
    [SerializeReference] protected List<string> candidateDescribe=new List<string>();

    /// <summary>
    /// 获取证据的名字
    /// </summary>
    /// <returns></returns>
    public string GetEvidenceName() 
    {
        return evidenceName;
    }
    /// <summary>
    /// 获取证据的描述
    /// </summary>
    /// <returns></returns>
    public string GetDescribe() 
    {
        return describe;
    }
    /// <summary>
    /// 修改证据的描述
    /// </summary>
    /// <param name="desc"></param>
    protected void ChangeDescribe(string desc) 
    {
        describe = desc;
    }
}
