using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;  

public class InteractiveManager : SingletonAutoMono<InteractiveManager>
{
    

    //开门系列，使用playerfrebs键值对实现
    public void OpenDoor(string _doorNum)
    {
        //输入对应门的编号(int)打开这个门，门的编号设置在门对应物体上
        PlayerPrefs.SetInt(_doorNum,1);
        Debug.Log("Door "+_doorNum+"is Open (Mgr)");
        //1代表该门的状态是开启
    }

    public void CloseDoor(string _doorNum)
    {
        //输入对应门的编号(int)关闭这个门
        PlayerPrefs.SetInt(_doorNum,0);
        Debug.Log("Door "+_doorNum+"is Close (Mgr)");
        //0代表该门的状态应该是关闭
    }

   
    public void EnterProblem(string quizName)
	{
        StaticPanelMgr.GetInstance().LoadPanel(quizName);
    }

    //通过字符串，或者场景的index来切换场景
    public void ChangeSence(string _position)
    {
        SceneManager.LoadScene(_position);
    }
    public void ChangeSence(int _position)
    {
        SceneManager.LoadScene(_position);
    }
}
