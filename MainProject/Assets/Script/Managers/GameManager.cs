using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public enum PlotEvent:int
{
    GAME_START=0,
    NULL=-1,

    ENTER_BOOKSHEL=2

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
    public delegate void PlayerSpeak(string topic);
    public event PlotHandler GameStart;
    public event PlayerSpeak PlayerSay;

    public void StartPlot(PlotEvent plot)
    {
        switch((int)plot)
        {
            case -1:break;
            case 0:
            {
                GameStart();
                break;
            }
        }
    }

    public void StartSpeaking(string topic)
    {
        PlayerSay(topic);
    }    
}
