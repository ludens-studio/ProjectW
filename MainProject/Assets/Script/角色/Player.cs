using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Speaker
{
   new void Start()
   {
     base.Start();
     GameManager.GetInstance().PlayerSay+=Talk;
   } 
}
