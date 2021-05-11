using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTest : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown (KeyCode.P)){
            //StaticPanelMgr.GetInstance().LoadPanel("静态面板/书架");
            //GameObject o = (GameObject)Resources.Load("静态面板/书架");
            GameObject hp_bar = (GameObject)Resources.Load("静态面板/书架");
            GameObject mUICanvas = GameObject.Find("StaticCanvas"); 
            hp_bar = Instantiate(hp_bar, hp_bar.transform.position, hp_bar.transform.rotation, mUICanvas.transform); 
            hp_bar.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0 , 0);
            //hp_bar.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 855, 855);


        }
        if(Input.GetKeyDown(KeyCode.O)){
            StaticPanelMgr.GetInstance().LeavePanel();
        }
    }
}
