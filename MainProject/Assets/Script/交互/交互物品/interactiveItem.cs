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
    private bool canUse = false ; //是否处于可交互状态
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
            if(Input.GetKeyDown(KeyCode.T))
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
        StaticPanelMgr.GetInstance().LoadPanel("静态面板/"+puzzelName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //进入时
        if(other.tag == "Player")
        {
            canUse = true ;     
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //退出时
        if(other.tag == "Player")
        {

        }
    }
}
