using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Speaker
{
    private PlayerControl playerControl;
    private Animator animator;
   new void Start()
   {
     base.Start();
     PlayerControl.GetInstance().plotAni=true;
     animator=gameObject.GetComponent<Animator>();
     playerControl=PlayerControl.GetInstance();
     playerControl.Pause();
   }

    protected override void Subscribe()
    {
        gameManager.LateToMeet+=LateToMeet;
        gameManager.GameStart+=GameStart;
    }

 

   private void LateToMeet()
   {
     playerControl.Pause();
     animator.Play("侦探坐下");
   }

   private void GameStart()
   {
     playerControl.plotAni=false;
     animator.Play("侦探静息");
   } 
}
