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
    /// text������ݶ����ݣ�δ�����޸�Ϊimage���
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
    /// ��ť�¼������ڴ򿪵���ѡ�����
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
    /// ��ȡ����
    /// </summary>
    /// <returns></returns>
    public string GetTool() 
    {
        return currentTool;
    }

    /// <summary>
    /// �ı䵱ǰ�ֳֵ���
    /// </summary>
    /// <param name="toolName"></param>
    public void ChangeTool(string toolName) 
    {
        currentTool = toolName;
        currentToolText.text = currentTool;
    }
}
