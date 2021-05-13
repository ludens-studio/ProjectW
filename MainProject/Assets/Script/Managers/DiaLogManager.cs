using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class DiaLogManager : SingletonMono<DiaLogManager>
{

    public DialogContent[] boringWords; 
    //对话框的UI
    public GameObject dialogBox ; 
    //输出的内容以及说话者的名字
    public Text dialogText , nameText ; 

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
    }

    void Update()
    {
        
        if(!talking)return;
        if(Input.GetKeyDown(KeyCode.T))
        {
            currentLine ++ ; 
            if(currentLine < dialogLines.Length)
            {
                currentLine=0;
                dialogText.text = dialogLines[currentLine]+"（按T继续）";
            }
            else
            {
                currentLine = 0 ; 
                animator.Play("Hide");
                PlayerControl.GetInstance().EnableMove();
                talking=false;
            } 

        }
       
    }

    public void ShowDialog( bool _hasName)
    {
        animator.Play("Show");
        talking=true;
       if(!_hasName) nameText.text="Player";
       else nameText.text=speaker;
        PlayerControl.GetInstance().Pause(); //限制玩家在对话状态不可移动
        dialogText.text=dialogLines[currentLine]+"（按T继续）";
    }

    public void SetContext(DialogContent content)
    {
        dialogLines=content.GetContext();
        speaker=content.GetSpeaker();
        if(!talking)ShowDialog(speaker==null);
    }

    /// <summary>
    /// 一些不可能存在交互的简单对话，为内置内容
    /// </summary>
    /// <param name="idx"></param>
    public void BoringSpeak(int idx)
    {
        SetContext(boringWords[idx]);
    }
 

    /// <summary>
    /// 用于对物品进行描述
    /// </summary>
    /// <param name="describe"></param>
    private void ShowDescribe(string eviname)
    {
        BaseEvidence evidence=EvidenceManager.GetInstance().allEvidences.GetObjectEvidence(eviname);
        if(evidence==null) evidence=EvidenceManager.GetInstance().allEvidences.GetObjectEvidence(eviname);
        string describe =evidence.GetDescribe();
        string[] context={describe};
        dialogLines=context;
        ShowDialog(false);
    }

    void OnDestroy()
    {
        EvidenceManager.GetInstance().AddObjectEvent-=ShowDescribe;
        EvidenceManager.GetInstance().AddWordEvent-=ShowDescribe;
    }
}
