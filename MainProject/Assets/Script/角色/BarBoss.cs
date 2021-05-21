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
    }
    protected override void Subscribe()
    {
        
    }
}
