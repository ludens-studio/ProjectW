using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public enum PlotEvent:int
{
    GAME_START=0,
    NULL=-1,
    ENTER_BOOKSHEL=1,

    LATE_TO_MEET=2

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
                Cursor.visible=false;
                PlayerControl.GetInstance().Pause();
                StartSpeaking("进入书架");
                break;
            } 
            case 2:
            {
                LateToMeet();
                break;
            }
        }
    }

    private void StartSpeaking(string topic)
    {
        player.Talk(topic);
    }    
}
