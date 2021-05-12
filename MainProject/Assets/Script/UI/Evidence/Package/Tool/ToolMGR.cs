using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolMGR : MonoBehaviour
{
    private static ToolMGR instance;
    [SerializeField]private string currentTool="空";
    public Image toolImage;
    private Animator anitor;
    private bool isOpen = false;


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
    /// 动画器切换道具状态
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
    /// 获取当前使用的工具
    /// </summary>
    /// <returns></returns>
    public string GetTool() 
    {
        return currentTool;
    }

    /// <summary>
    /// 改变现在工具的内容
    /// </summary>
    /// <param name="toolName"></param>
    public void ChangeTool(string toolName,Sprite sprite) 
    {
        currentTool = toolName;
        toolImage.sprite=sprite;
    }
}
