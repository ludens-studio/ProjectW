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
    [SerializeReference]private string speaker;
    [SerializeReference]public string topic; 

    [SerializeReference]private PlotEvent plot=PlotEvent.NULL;
    [SerializeReference]private DialogContent nextContent;
        
        [TextArea(1,3)]
    [SerializeReference]
    /// <summary>
    /// 对话内容
    /// </summary>
    private string[] context;

    /// <summary>
    /// 获取具体对话数组
    /// </summary>
    /// <returns></returns>
    public String[] GetContext()
    {
        return context;
    }
    /// <summary>
    /// 获取是谁说话
    /// </summary>
    /// <returns></returns>
    public string GetSpeaker()
    {
        return speaker;
    }

    public PlotEvent GetPlot()
    {
        return plot;
    }

    public DialogContent GetNextContent()
    {
        return nextContent;
    }
}

