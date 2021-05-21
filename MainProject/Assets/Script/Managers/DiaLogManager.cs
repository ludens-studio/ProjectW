using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class DiaLogManager : SingletonMono<DiaLogManager>
{
    private AllEvidence evidences;
    public DialogContent[] boringWords; 
    //对话框的UI
    public GameObject dialogBox ; 
    //输出的内容以及说话者的名字
    public TextMeshProUGUI dialogText , nameText ; 

    private DialogContent currentDialog;

    private GameObject tool;

    [HideInInspector]
    public string[] dialogLines ; //对话框输出内容
    [SerializeField] private int currentLine ; //实时追踪是行，哪个元素在输出

    public string speaker ; //说话者

    [SerializeField]private Animator animator;
    private bool talking=false;

    void Start()
    {
        tool=ToolMGR.GetInstance().gameObject;
        EvidenceManager.GetInstance().AddObjectEvent+=ShowDescribe;
        EvidenceManager.GetInstance().AddWordEvent+=ShowDescribe;
        evidences=EvidenceManager.GetInstance().allEvidences;
    }

    void Update()
    {

        if(!talking)return;
        if(Input.GetKeyDown(KeyCode.T))
        {
            currentLine ++ ; 
            if(currentLine < dialogLines.Length)
            {
                dialogText.text = dialogLines[currentLine];
            }
            else
            {
                EndContent();
            } 
        }    
    }

    public void ShowDialog()
    {
        if(!talking)
        {
         talking=true;
         PlayerControl.GetInstance().Pause(); //限制玩家在对话状态不可移动
        }
        animator.Play("Show");
        nameText.text=speaker;
        dialogText.text=dialogLines[currentLine];
        tool.SetActive(false);
    }

    /// <summary>
    /// 设置具体对话的内容
    /// </summary>
    /// <param name="content"></param>
    public void SetContext(DialogContent content)
    {
        currentDialog=content;
        dialogLines=content.GetContext();
        speaker=content.GetSpeaker();
        nameText.text=content.GetSpeaker();
        ShowDialog();
    }

    /// <summary>
    /// 一些不可能存在交互的简单对话，为内置内容
    /// </summary>
    /// <param name="idx"></param>
    public void BoringSpeak(int idx)
    {
        speaker="侦探";
        SetContext(boringWords[idx]);
    }
 

    /// <summary>
    /// 用于对物品进行描述
    /// </summary>
    /// <param name="describe"></param>
    private void ShowDescribe(string eviname)
    {
        DialogContent content=evidences.GetObjectEvidence(eviname).GetContent();
        SetContext(content);
    }

    private void EndContent()
    {
        currentLine=0;
        DialogContent nextTopic=currentDialog.GetNextContent();
        PlotEvent plot=currentDialog.GetPlot();
        if(nextTopic==null)
        {
            currentDialog=null;
            animator.Play("Hide");
            talking=false;
        }
        else
        {
            SetContext(nextTopic);
            ShowDialog();
        }
        GameManager.GetInstance().StartPlot(plot);
    }

    private void OnDestroy()
    {
        EvidenceManager.GetInstance().AddObjectEvent-=ShowDescribe;
        EvidenceManager.GetInstance().AddWordEvent-=ShowDescribe;
    }

}
