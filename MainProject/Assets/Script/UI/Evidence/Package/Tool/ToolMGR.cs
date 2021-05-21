using UnityEngine;
using UnityEngine.UI;

public class ToolMGR : SingletonMono<ToolMGR>
{
    private static ToolMGR instance;
    [SerializeField]private string currentTool="null";
    public Image toolImage;
    public Sprite emptySprite;
    private PackageSlot currentSlot;

    void Start()
    {
            EvidenceManager.GetInstance().RemoveObjectEvent+=CancleTool;
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
        if(toolName.Equals(currentTool)) CancleTool(currentTool);
        else
        {
            AllEvidence evidence=EvidenceManager.GetInstance().allEvidences;
            currentTool=toolName;
            toolImage.sprite=evidence.GetObjectEvidence(toolName).GetSprite();
        }
    }

    public void CancleTool(string tool)
    {
        if(!tool.Equals(currentTool)) return;
        else 
        {
            currentTool="null";
            toolImage.sprite=emptySprite;
        }
    }
}
