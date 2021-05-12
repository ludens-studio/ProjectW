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
    }
    void BookOnClick()
    {
        //在这里把道具加入背包
        //需要防止重复添加发生
        EvidenceManager.GetInstance().AddObjectEvidence("奇怪的血迹");
        getBook.interactable=false;
    }
    void BloodOnClick()
    {
        //在这里把道具加入背包
        //需要防止重复添加发生
        EvidenceManager.GetInstance().AddObjectEvidence("放错的书");
        getBlood.interactable=false;
    }
    public void ExitPanel(){
        StaticPanelMgr.GetInstance().LeavePanel();
    }
}
