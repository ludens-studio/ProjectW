using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPanelMgr : SingletonAutoMono<StaticPanelMgr>
{
    //已加载的静态面板列表
    private List<GameObject> panelList = new List<GameObject>();
    //当前静态面板
    private static GameObject currentPanel = null;
    
    /// <summary>
    /// 加载对应路径上的房间预制件，name写路径
    /// </summary>
    public void LoadPanel(string name)
    {
        //检查是否已经实例化过
        foreach(GameObject panel in panelList)
        {
            PlayerControl.GetInstance().Pause();
            if(panel.name == name){
                panel.SetActive(true);
                currentPanel = panel;
                return;
            }
        }
        GameObject o = (GameObject)Resources.Load(name);
        GameObject mUICanvas = GameObject.Find("StaticCanvas"); 
        o = Instantiate(o, o.transform.position, o.transform.rotation, mUICanvas.transform); 
        o.name = name;
        panelList.Add(o);
        currentPanel = o;
    }

    /// <summary>
    /// 离开静态面板
    /// </summary>
    public void LeavePanel()
    {
        if(currentPanel!=null) currentPanel.SetActive(false);
        PlayerControl.GetInstance().EnableMove();
    }
}
