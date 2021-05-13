using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInRoom : TalkableObject
{
    public override void EndAquire()
    {
        Destroy(gameObject);
    }
    //动态获取，在走近时按下回车获取道具
    public override void StartAquire()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            //啊这但是真的是这样写的吗
        }else{
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) InteractAction();
    }
}
