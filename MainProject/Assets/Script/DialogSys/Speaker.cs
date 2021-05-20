using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    private GameManager gameManager;
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

}
