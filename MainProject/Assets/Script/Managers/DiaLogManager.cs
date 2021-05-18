using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class DiaLogManager : SingletonMono<DiaLogManager>
{
    private AllEvidence evidences;
    public DialogContent[] boringWords; 
    //对话框的UI
    public GameObject dialogBox ; 
    //输出的内容以及说话者的名字
    public Text dialogText , nameText ; 

    private DialogContent currentDialog;

    [HideInInspector]
    public string[] dialogLines ; //对话框输出内容
    [SerializeField] private int currentLine ; //实时追踪是行，哪个元素在输出

    public string speaker ; //说话者

    [SerializeField]private Animator animator;
    private bool talking=false;

    void Start()
    {
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
                dialogText.text = dialogLines[currentLine]+"（按T继续）";
            }
            else
            {
                currentLine = 0 ; 
                EndContent();
            } 
        }    
    }

    public void ShowDialog()
    {
        animator.Play("Show");
        talking=true;
        nameText.text=speaker;
        PlayerControl.GetInstance().Pause(); //限制玩家在对话状态不可移动
        dialogText.text=dialogLines[currentLine]+"（按T继续）";
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
        if(!talking)ShowDialog();
        nameText.text=content.GetSpeaker();

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
        DialogContent nextTopic=currentDialog.GetNextContent();
        PlotEvent plot=currentDialog.GetPlot();
        if(nextTopic==null)
        {
            currentDialog=null;
            animator.Play("Hide");
            talking=false;
            PlayerControl.GetInstance().EnableMove();
        }
        else
        {
            SetContext(nextTopic);
        }
        GameManager.GetInstance().StartPlot(plot);
    }

    private void OnDestroy()
    {
        EvidenceManager.GetInstance().AddObjectEvent-=ShowDescribe;
        EvidenceManager.GetInstance().AddWordEvent-=ShowDescribe;
    }

}
