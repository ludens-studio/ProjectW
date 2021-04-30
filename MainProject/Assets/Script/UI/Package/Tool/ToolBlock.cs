using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBlock : MonoBehaviour
{
    /// <summary>
    /// toolText�����ǲ���ʹ�ã��ǵ��޸�
    /// </summary>
    private Text toolText;
    /// <summary>
    /// toolName�����ǹ������ԣ������޸�
    /// </summary>
    private string toolName;


    private void Start()
    {
        toolText = gameObject.GetComponentInChildren<Text>();
        toolName = toolText.text;
    }
    /// <summary>
    /// ѡ��ǰ����
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
