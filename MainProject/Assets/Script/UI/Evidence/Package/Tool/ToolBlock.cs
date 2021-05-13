using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBlock : MonoBehaviour
{

    [SerializeField]private string toolName;
    private Image image;

    public bool isHand=false;

    private void Start()
    {
        image=gameObject.GetComponent<Image>();
    }
    /// <summary>
    /// 按钮事件
    /// </summary>
    public void ChooseTool() 
    {
        var toolMGR = ToolMGR.GetInstance();
        Sprite tem = image.sprite;
        string temName=toolMGR.GetTool();
        image.sprite=toolMGR.toolImage.sprite;

        toolMGR.ChangeTool(toolName,tem,this);
        toolName=temName;

        toolMGR.ShowTools();
    }

    /// <summary>
    /// 如果是手持道具格子，更换格子休闲
    /// </summary>
    /// <param name="newTool"></param>
    public void SetTool(string newTool)
    {
        toolName=newTool;
        image.sprite=EvidenceManager.GetInstance().package.GetEvidence(newTool).GetSprite();
    }
}
