using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : SingletonAutoMono<InteractiveManager>
{
    public Door CurrentDoor;


    public void EnterProblem(string quizName)
	{
        StaticPanelMgr.GetInstance().LoadPanel(quizName);
    }

}
