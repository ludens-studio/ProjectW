using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBlock : MonoBehaviour
{

    [SerializeField]private string toolName;
    private Image image;
    private Sprite toolSprite;

    private void Start()
    {
        image=gameObject.GetComponent<Image>();
        toolSprite=image.sprite;
    }
    /// <summary>
    /// 按钮事件
    /// </summary>
    public void ChooseTool() 
    {
        var toolMGR = ToolMGR.GetInstance();
        Sprite tem = toolSprite;
        string temName=toolMGR.GetTool();
        image.sprite=toolMGR.toolImage.sprite;

        toolMGR.ChangeTool(toolName,tem);
        toolName=temName;
        toolSprite=image.sprite;

        toolMGR.ShowTools();
    }
}
