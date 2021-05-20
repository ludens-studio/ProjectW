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

    ///<summary>
    /// 游戏开幕
    /// </summary>  
    LATE_TO_MEET=1,

    /// <summary>
    /// 获得白酒
    /// </summary>
    GET_WINE=2,

    ///<summary>
    /// 获得新酒
    /// </summary>
    GET_NEW_WINE=3,
    ///<summary>
    /// 重新去拿白酒
    /// </summary>
    GO_BACK_FOR_WINE=4,

    /// <summary>
    /// 进入书架视角
    /// </summary>
    ENTER_BOOKSHEL=6,
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
    private EvidenceManager evidenceManager;
    void Start()
    {
        player=PlayerControl.GetInstance().gameObject.GetComponent<Player>();
        evidenceManager=EvidenceManager.GetInstance();
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
            case 2:
            {
                EvidenceManager.GetInstance().AddObjectEvidence("白酒");
                break;
            }
            case 3:
            {
                evidenceManager.AddObjectEvidence("新酒");
                break;
            }
            case 4:
            {
                player.transform.localScale=new Vector3(0.2f,0.2f);
                break;
            }
            case 5:
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
