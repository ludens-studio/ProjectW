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

    public void SelectTool(PackageSlot slot)
    {
        if(currentSlot=null) currentSlot=slot;
        ChangeTool(slot.GetEvidenceName());
    }

    /// <summary>
    /// 改变现在工具的内容
    /// </summary>
    /// <param name="toolName"></param>
    private void ChangeTool(string toolName) 
    {
       Package evidence=EvidenceManager.GetInstance().package;
       currentTool=toolName;
       toolImage.sprite=evidence.GetEvidence(toolName).GetSprite();
    }

    public void CancleTool(string tool)
    {
        if(!tool.Equals(currentTool)) return;
        else 
        {
            currentTool=null;
            toolImage.sprite=emptySprite;
        }
    }
}
