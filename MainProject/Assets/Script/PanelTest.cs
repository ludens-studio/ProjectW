using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTest : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown (KeyCode.P)){
            StaticPanelMgr.GetInstance().LoadPanel("静态面板/书架");
        }
        if(Input.GetKeyDown(KeyCode.O)){
            StaticPanelMgr.GetInstance().LeavePanel();
        }
    }
}
