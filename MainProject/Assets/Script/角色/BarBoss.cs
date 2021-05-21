using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBoss : NPC
{
    new void Start()
    {
        base.Start();
        defaultTopic="酒吧对白";
        ModifyToolContent("白酒","酒吧对峙");
        ModifyToolContent("新酒","换酒");
        uselessTool="对峙失败";
    }
    protected override void Subscribe()
    {
        gameManager.GetWine+=GetWine;
        gameManager.FinishTur+=FinishTour;
        gameManager.BossIntro+=Boss_Intro;
    }

    private void GetWine()
    {
        defaultTopic="换酒";
        uselessTool="换酒";
    }

    private void FinishTour()
    {
        defaultTopic="老板身份";
        uselessTool="老板身份";
    }

    private void Boss_Intro()
    {
        defaultTopic="寒暄";
        uselessTool="无可奉告";
    }
}
