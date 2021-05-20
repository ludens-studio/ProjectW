using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : NPC
{
    private new void Start()
    {
        base.Start();
        talkable=false;
    }

    private void LateToMeet()
    {
        Talk("开场白");   
    }

    protected override void Subscribe()
    {
        gameManager.LateToMeet+=LateToMeet;
    }
}
