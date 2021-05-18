using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShowTips : SingletonMono<ShowTips>
{
    //用于展示游戏提示（比如游戏已存档，获得成就等等）

    [Header("对应组件")]
    public GameObject thebackground ; 
    public Text theTitle ; //提示标题
    public Text theText ; //提示文本

    [Header("展示时间")]
    public int showTime = 2 ;

    private float time ; 

    private void Update()
    {
        time += Time.deltaTime ;
       // Debug.Log(time);
       if(Input.GetKeyDown(KeyCode.M)){
           AchievementManager.GetInstance().GetAchievement("<b>Thank you!</b> \n 谢谢你试玩Demo~");
           OpenTips();
       }

        if(Input.GetKeyDown(KeyCode.N)){
           CloseTips();
       }
    }


    /// <summary>
    /// 设置Tip显示，第一个是标题，第二个是文本
    /// </summary>
    public void SetTips(string _title , string _text){
        theTitle.text = _title;
        theText.text  = _text;
    }

    public void OpenTips(){
        thebackground.SetActive(true);
    }

    public void CloseTips(){
        thebackground.SetActive(false);
    }
}
