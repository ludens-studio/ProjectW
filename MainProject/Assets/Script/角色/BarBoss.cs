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
    }

    private void GetWine()
    {
        defaultTopic="换酒";
        uselessTool="换酒";
    }
}
