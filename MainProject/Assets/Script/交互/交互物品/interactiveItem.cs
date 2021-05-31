using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum INTERATION_TYPE:int
{
   DOOR=0,STATICPUZZEL=1
}

public class interactiveItem : MonoBehaviour
{    
    private ItemHighlighter highlighter;
    [SerializeReference]private INTERATION_TYPE actionType;
    [Header("STATICPUZZEL类型必须使用")]
    [SerializeReference]private string puzzelName;

    [Header("是否只能交互一次？")]
    public bool UseOnce ; //如果设置为true，那么只能被交互一次

    void Start()
    {
        highlighter=gameObject.GetComponent<ItemHighlighter>();
    }

    void Update()
    {
        if(highlighter.enter)
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                switch((int)actionType)
                {
                    case 1:
                    {
                        EnterPuzzel();
                        break;
                    }
                }
            }   
        }
    }

    private void EnterPuzzel()
    {
        StaticPanelMgr.GetInstance().SetPanel("StaticCanvas");
        StaticPanelMgr.GetInstance().LoadPanel("静态面板/"+puzzelName);
    }

}
