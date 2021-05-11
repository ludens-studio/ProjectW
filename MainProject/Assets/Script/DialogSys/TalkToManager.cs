using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToManager : MonoBehaviour
{
    public string talker;
    public DialogContent[] contents;
    private Dictionary<String,DialogContent> topics;

    void Start()
    {
        if(contents.Length==0) return;
        Dictionary<String,DialogContent> topics=new Dictionary<string, DialogContent>();
        foreach(DialogContent con in contents)
        {
            topics.Add(con.topic,con);
        }
    }
    public void Talk(String topic)
    {
        DiaLogManager.GetInstance().SetContext(topics[topic]);
        DiaLogManager.GetInstance().ShowDialog(talker.Equals(null));
    }

}
