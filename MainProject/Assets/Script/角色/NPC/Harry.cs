using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : NPC
{
    [SerializeReference]private Collider2D coll;
    private Animator animator;
    private new void Start()
    {
        base.Start();
        talkable=false;
        defaultTopic="准备出发";
        uselessTool="准备出发";
        animator=gameObject.GetComponent<Animator>();
    }

    protected override void Subscribe()
    {
        gameManager.LateToMeet+=LateToMeet;
        gameManager.FinishTur+=FinishTour;
        gameManager.EnterScene+=EnterScene;
        gameManager.ExitBookShell+=ExitBookShell;
        gameManager.EndShellPuzzel+=EndShellPuzzel;
        gameManager.FailedShellPuzzel+=EndShellPuzzel;
    }

    private void LateToMeet()
    {
        Talk("开场白");   
    }

    private void FinishTour()
    {
        talkable=true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player")) 
        {
            if(!ToolMGR.GetInstance().GetTool().Equals("新酒")) Talk("酒拿到了吗");
            else 
            {
                coll.enabled=false;
                Talk("结束教程");
            }
        }
    }

    private void EnterScene()
    {
        Talk("现场介绍");
        transform.position=new Vector3(21f,transform.position.y);
        animator.Play("哈里静息");
        defaultTopic="默认";
        uselessTool="默认";
    }

    private void EndShellPuzzel()
    {
        ModifyToolContent("奇怪的血迹","默认");
        defaultTopic="默认";
        Talker.GetInstance().target=null;
    }

    private void ExitBookShell()
    {
        Talker.GetInstance().target=this;
        ModifyToolContent("奇怪的血迹","书架2");
        uselessTool="书架解密失败";
        Talk("书架");
    }
}
