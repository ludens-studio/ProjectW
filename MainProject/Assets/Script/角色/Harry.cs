using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : Speaker
{
    
    private Collider2D coll;

    new void Start()
    {
        base.Start();
        coll=gameObject.GetComponent<Collider2D>();
    }
    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            PlayerControl.GetInstance().Pause();
            Talk("开场白");
            coll.enabled=false;
        }
    }
}
