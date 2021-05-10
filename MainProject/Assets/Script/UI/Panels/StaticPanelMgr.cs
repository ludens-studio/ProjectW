using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPanelMgr : BaseManager<StaticPanelMgr>
{
    //已加载的静态面板列表
    private List<GameObject> panelList = new List<GameObject>();
    //当前静态面板
    private static GameObject currentPanel;
    
    /// <summary>
    /// 加载对应路径上的房间预制件，name写路径
    /// </summary>
    public void LoadPanel(string name){
        //检查是否已经实例化过
        foreach(GameObject panel in panelList){
            if(panel.name == name){
                panel.SetActive(true);
                currentPanel = panel;
                return;
            }
        }
        //注意一下，这里的name要写成路径，比如UI文件夹下的a图片，name应该是UI/a
        ResMgr.GetInstance().LoadAsync<GameObject>(name,(o) =>
        {
            o.name = name;
            panelList.Add(o);
            currentPanel = o;
        });
    }

    /// <summary>
    /// 离开静态面板
    /// </summary>
    public void LeavePanel(){
        if(currentPanel!=null)
            currentPanel.SetActive(false);
    }
}
