using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolMGR : MonoBehaviour
{
    private static ToolMGR instance;
    private string currentTool="Hand";
    private Animator anitor;
    private bool isOpen = false;
    /// <summary>
    /// text组件是暂定内容，未来会修改为image组件
    /// </summary>
    [SerializeReference] Text currentToolText;

    private void Awake()
    {
        instance = this;
        anitor = gameObject.GetComponent<Animator>();
    }

    public static ToolMGR GetInstance() 
    {
        return instance;
    }

    /// <summary>
    /// 按钮事件，用于打开道具选择面板
    /// </summary>
    public void ShowTools() 
    {
        if (!isOpen)
        {
            anitor.Play("Show");
            isOpen = true;
        }
        else 
        {
            anitor.Play("Hide");
            isOpen = false;
        }
    }


    /// <summary>
    /// 获取道具
    /// </summary>
    /// <returns></returns>
    public string GetTool() 
    {
        return currentTool;
    }

    /// <summary>
    /// 改变当前手持道具
    /// </summary>
    /// <param name="toolName"></param>
    public void ChangeTool(string toolName) 
    {
        currentTool = toolName;
        currentToolText.text = currentTool;
    }
}
