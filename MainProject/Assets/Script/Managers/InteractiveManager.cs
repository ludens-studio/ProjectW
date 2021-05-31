using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : SingletonAutoMono<InteractiveManager>
{
    public Door CurrentDoor;


    public void EnterProblem(string quizName)
	{
        StaticPanelMgr.GetInstance().SetPanel("StaticCanvas");
        StaticPanelMgr.GetInstance().LoadPanel(quizName);
    }

}
