using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;


public class AchievementManager : SingletonAutoMono<AchievementManager>
{
    private int theImpression ; //好感度的值，这次可能用不上，我觉得这个Mgr太单薄所以写在这里了
    public List<string> Achievements = new List<string>(); // 成就栏

    /// <summary>
    /// 显示获得成就的名字，输入参数是成就名字
    /// </summary>
    public void GetAchievement(string _name)
    {
        //1.设置专门的UI弹出提示

        //2.在List里面设置对应的成就

        //3.通过playerPrefs来保存成就进度，直接使用 _name对应 , 1代表该成就已经得到
        PlayerPrefs.SetInt(_name, 1);
    }

    /// <summary>
    /// 更新成就的获取情况
    /// </summary>
    /// <param name="_name"></param>
    public void UpdateTheAchievement(string _name)
    {

    }

    /// <summary>
    /// 调整好感度的方法，第一个代表加减(1加0减)，第二个代表数值
    /// </summary>   
    public void ChangeTheImpression(int a , int b)
    {
        if(a == 1)
        {
            //增加
            theImpression += b;
        }

        if(a == 0)
        {
            //减少
            theImpression -= b;
        }
    }
}