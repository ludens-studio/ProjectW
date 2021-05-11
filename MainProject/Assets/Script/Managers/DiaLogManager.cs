using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class DiaLogManager : SingletonMono<DiaLogManager>
{

    //对话框的UI
    public GameObject dialogBox ; 
    //输出的内容以及说话者的名字
    public Text dialogText , nameText ; 

    [TextArea(1,3)]
    public string[] dialogLines ; //对话框输出内容
    [SerializeField] private int currentLine ; //实时追踪是行，哪个元素在输出

    public string speaker ; //说话者

    [SerializeField]private Animator animator;
    private bool talking=false;

    void Update()
    {
        
        if(!talking)return;
        if(Input.GetKeyDown(KeyCode.T))
        {
            currentLine ++ ; 
            if(currentLine < dialogLines.Length)
            {
                currentLine=0;
                CheckName(); 
                dialogText.text = dialogLines[currentLine]+"（按T继续）";
            }
            else
            {
                currentLine = 0 ; 
                animator.Play("Hide");
                PlayerControl.GetInstance().canMove = true ;
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
        PlayerControl.GetInstance().canMove = false ; //限制玩家在对话状态不可移动
        dialogText.text=dialogLines[currentLine]+"（按T继续）";
    }

    public void SetContext(DialogContent content)
    {
        dialogLines=content.GetContext();
    }

    private void CheckName()
    {
        //检测该行是否是“代表玩家名字”的字符行
        //实现途径是利用StartWith来进行判断，通过检测字符串的开头得到对应的布尔值
        if(dialogLines[currentLine].StartsWith("n-")){
            //将对应名字的文本框的文本，传递给UI中的NameText
            nameText.text = dialogLines[currentLine].Replace("n-",""); //将前文的n-替换掉，从而得到正确的名字显示 
            currentLine ++ ;
        }
    } 

    /// <summary>
    /// 用于对物品进行描述
    /// </summary>
    /// <param name="describe"></param>
    public void ShowDescribe(string describe)
    {
        string[] context={describe};
        dialogLines=context;
        ShowDialog(false);
    }
}
