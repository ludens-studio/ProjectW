using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : SingletonMono<Talker>
{
   public NPC target=null;
   private void Update()
   {
       if(target!=null)
       {
            if(target.canTalk()&&Input.GetKeyDown(KeyCode.T)) target.Talk(target.GetDefaultTopic());
            else if(Input.GetKeyDown(KeyCode.U)) target.TalkWithTool();
       }
   }

}
