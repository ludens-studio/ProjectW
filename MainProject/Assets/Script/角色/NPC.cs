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
    /// 对于对给予道具毫无意义的话题说明
    /// </summary>
    [SerializeReference]protected string uselessTool;
    
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

    protected bool talkable=true;


    public override void Talk(string topic)
    {
        ChangeTalkableStatus(false);
        base.Talk(topic);
    }  
    
    /// <summary>
    /// 与证据对话
    /// </summary>
    protected void TalkWithTool()
    {
        string tool=ToolMGR.GetInstance().GetTool();
        if(!toolTopic.ContainsKey(tool))
        {
            Talk(toolTopic[tool]);
        }
        else Talk(uselessTool);
        ChangeTalkableStatus(false);
    }

    private void Update()
    {
        if(!talkingTip.activeSelf) return;

        if(Input.GetKeyDown(KeyCode.T)) Talk(defaultTopic);
        else if(Input.GetKeyDown(KeyCode.T)) TalkWithTool();
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
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.tag.Equals("Player")) return;
        talkingTip.SetActive(true);
        ChangeTalkableStatus(true);
    }
}
