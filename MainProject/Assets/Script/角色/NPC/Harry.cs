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

    void OnColliderEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            PlayerControl.GetInstance().Pause();
            Talk("开场白");
        }
    }

    private void DisableTrigger()
    {
        coll.enabled=false;
    }
}
