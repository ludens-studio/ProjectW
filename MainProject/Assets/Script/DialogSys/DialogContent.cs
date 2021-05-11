using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/// <summary>
/// 对话的主题与对话的内容
/// </summary>
[CreateAssetMenu(fileName = "DialogContent", menuName = "ScriptableObject/DialogContent")]
public class DialogContent : ScriptableObject
{
    /// <summary>
    /// 对话主题
    /// </summary>
    /// <value></value>
    [SerializeField]
    public string topic{get=>topic;} 
    [SerializeField]
    /// <summary>
    /// 对话内容
    /// </summary>
    private String[] context;

    /// <summary>
    /// 获取具体对话数组
    /// </summary>
    /// <returns></returns>
    public String[] GetContext()
    {
        return context;
    }
}

