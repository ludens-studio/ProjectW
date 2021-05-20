using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

/// <summary>
/// 用于选择开启的情节
/// </summary>
public enum PlotEvent:int
{
    ///<summary>
    /// 啥都没有
    ///<summary>
    NULL=-1,
    /// <summary>
    /// 停止动画，允许操作
    /// </summary>
    GAME_START=0,
    /// <summary>
    /// 开场剧情
    /// </summary>
    LATE_TO_MEET=1,
    /// <summary>
    /// 进入书架视角
    /// </summary>
    ENTER_BOOKSHEL=3,


}
public class GameManager : SingletonAutoMono<GameManager>
{
    /// <summary>
    /// 选择情节
    /// </summary>
    public delegate void PlotHandler();
    /// <summary>
    /// 选择玩家说话的主题
    /// </summary>
    /// <param name="topic"></param>
    public event PlotHandler GameStart;
    public event PlotHandler LateToMeet;

    private Player player;

    void Start()
    {
        player=PlayerControl.GetInstance().gameObject.GetComponent<Player>();
    }

    /// <summary>
    /// 开启情节
    /// </summary>
    /// <param name="plot"></param>
    public void StartPlot(PlotEvent plot)
    {
        switch((int)plot)
        {
            case -1:break;
            case 0:
            {
                Cursor.visible=true;
                GameStart();
                break;
            }       
            case 1:
            {
                LateToMeet();
                break;
            }
            case 3:
            {
                Cursor.visible=false;
                PlayerControl.GetInstance().Pause();
                StartSpeaking("进入书架");
                break;
            } 
        }
    }

    private void StartSpeaking(string topic)
    {
        player.Talk(topic);
    }    
}
