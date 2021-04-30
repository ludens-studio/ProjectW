using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBlock : MonoBehaviour
{
    /// <summary>
    /// toolText属性是测试使用，记得修改
    /// </summary>
    private Text toolText;
    /// <summary>
    /// toolName属性是固有属性，不能修改
    /// </summary>
    private string toolName;


    private void Start()
    {
        toolText = gameObject.GetComponentInChildren<Text>();
        toolName = toolText.text;
    }
    /// <summary>
    /// 选择当前工具
    /// </summary>
    public void ChooseTool() 
    {
        var toolMGR = ToolMGR.GetInstance();
        string tem = toolName;
        toolName = toolMGR.GetTool();
        toolText.text = toolName;
        toolMGR.ChangeTool(tem);
        ToolMGR.GetInstance().ShowTools();
    }
}
