using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 书架的总控制
/// </summary>
/// <returns>
public class Bookshelf : MonoBehaviour
{
    public Button getBook;              //点击获取“带血的书的照片”道具
    public Button getBlood;             //点击获取“奇怪的血液的照片”道具
    public Button panelExiter;          //离开面板
    void Start()
    {
        getBook.GetComponent<Button>().onClick.AddListener(BookOnClick);
        getBlood.GetComponent<Button>().onClick.AddListener(BloodOnClick);
        panelExiter.GetComponent<Button>().onClick.AddListener(ExitPanel);
    }
    void BookOnClick()
    {
        //在这里把道具加入背包
        //需要防止重复添加发生
        print("获取带血的书");
    }
    void BloodOnClick()
    {
        //在这里把道具加入背包
        //需要防止重复添加发生
        print("获取奇怪的血液");
    }
    void ExitPanel(){
        StaticPanelMgr.GetInstance().LeavePanel();
        panelExiter.enabled = false;
    }
}
