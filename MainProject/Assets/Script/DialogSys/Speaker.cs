using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Speaker : MonoBehaviour
{
    protected GameManager gameManager;
    [SerializeReference]private string talker;
    public DialogContent[] contents;
    protected Dictionary<String,DialogContent> topics=new Dictionary<string, DialogContent>();

    protected virtual void Start()
    {
        gameManager=GameManager.GetInstance();
        if(contents.Length==0) return;
        foreach(DialogContent con in contents)
        {
            topics.Add(con.topic,con);
        }
        Subscribe();
    }
    
    /// <summary>
    /// 启用某段对话
    /// </summary>
    /// <param name="topic"></param>
    public virtual void Talk(String topic)
    {
        DiaLogManager.GetInstance().SetContext(topics[topic]);
        DiaLogManager.GetInstance().ShowDialog();
    }

    /// <summary>
    /// 订阅事件
    /// </summary>
    protected abstract void Subscribe();
}
