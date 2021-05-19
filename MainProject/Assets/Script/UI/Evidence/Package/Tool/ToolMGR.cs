using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolMGR : SingletonMono<ToolMGR>
{
    private static ToolMGR instance;
    [SerializeField]private string currentTool="null";
    public Image toolImage;
    public Sprite emptySprite;

    void Start()
    {
            EvidenceManager.GetInstance().RemoveObjectEvent+=ClearSprite;
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
    public void ChangeTool(string toolName) 
    {
       Package evidence=EvidenceManager.GetInstance().package;
       currentTool=toolName;
       toolImage.sprite=evidence.GetEvidence(toolName).GetSprite();
    }

    private void ClearSprite(string tool)
    {
        if(!tool.Equals(currentTool)) return;
        else 
        {
            currentTool=tool;
            toolImage.sprite=emptySprite;
        }
    }
}
