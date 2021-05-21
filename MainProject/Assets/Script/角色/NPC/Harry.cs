using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : NPC
{
    [SerializeReference]private Collider2D coll;
    private new void Start()
    {
        base.Start();
        talkable=false;
    }

    private void LateToMeet()
    {
        Talk("开场白");   
    }

    private void TalkToBoss()
    {
        talkable=true;
    }

    protected override void Subscribe()
    {
        gameManager.LateToMeet+=LateToMeet;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player")) Talk("酒拿到了吗");
    }
}
