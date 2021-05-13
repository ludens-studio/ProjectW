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

    private EvidenceManager evimgr;
    void Start()
    {
        getBook.GetComponent<Button>().onClick.AddListener(BookOnClick);
        getBlood.GetComponent<Button>().onClick.AddListener(BloodOnClick);
        evimgr=EvidenceManager.GetInstance();
    }
    void BookOnClick()
    {
        //在这里把道具加入背包
        //需要防止重复添加发生
        if(evimgr.package.GetEvidence("奇怪的血迹")==null) evimgr.AddObjectEvidence("奇怪的血迹");
        else DiaLogManager.GetInstance().BoringSpeak(0);
    }
    void BloodOnClick()
    {
        if(evimgr.package.GetEvidence("放错的书")==null) evimgr.AddObjectEvidence("放错的书");
        else DiaLogManager.GetInstance().BoringSpeak(0);
    }
    public void ExitPanel(){
        StaticPanelMgr.GetInstance().LeavePanel();
    }
}
