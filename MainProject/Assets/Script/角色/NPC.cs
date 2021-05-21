using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Speaker
{
    /// <summary>
    /// 默认情况下对于玩家没有任何交互的话题
    /// </summary>
    [SerializeReference]protected string defaultTopic;
    
    /// <summary>
    /// 针对于某种物品的聊天，start中手动初始化
    /// </summary>
    /// <typeparam name="string"></typeparam>
    /// <typeparam name="string"></typeparam>
    /// <returns></returns>
    protected Dictionary<string,string> toolTopic=new Dictionary<string, string>();
    /// <summary>
    /// 用于提示玩家可以对话的标志
    /// </summary>
    [SerializeReference]private GameObject talkingTip;
    /// <summary>
    /// 可以聊天的触发器
    /// </summary>
    [SerializeReference]private Collider2D trigger;
    [SerializeReference]protected string uselessTool;

    protected bool talkable=true;

    public override void Talk(string topic)
    {
        ChangeTalkableStatus(false);
        base.Talk(topic);
    }  
    
    /// <summary>
    /// 与证据对话
    /// </summary>
    public void TalkWithTool()
    {
        ToolMGR toolMGR=ToolMGR.GetInstance();
        string tool=toolMGR.GetTool();
        if(toolMGR.gameObject.activeSelf&&toolTopic.ContainsKey(tool))
        {
            Talk(toolTopic[tool]);
        }
        else Talk(uselessTool);
        ChangeTalkableStatus(false);
    }

    protected void ModifyToolContent(string key, string content)
    {
        if(toolTopic.ContainsKey(key)) toolTopic[key]=content;
        else toolTopic.Add(key,content);
    }

    protected void ChangeTalkableStatus(bool isActive)
    {
        if((!talkable)||(!isActive)) talkingTip.SetActive(false);
        else talkingTip.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!other.gameObject.tag.Equals("Player")) return;
        ChangeTalkableStatus(false);
        talker.target=null;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.tag.Equals("Player")) return;
        talkingTip.SetActive(true);
        ChangeTalkableStatus(true);
        talker.target=this;
    }

    public string GetDefaultTopic()
    {
        return defaultTopic;
    }

    public bool canTalk()
    {
        return talkingTip.activeSelf;
    }
}
