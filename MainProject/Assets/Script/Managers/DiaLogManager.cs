using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class DiaLogManager : SingletonAutoMono<DiaLogManager>
{

    //对话框的UI
    public GameObject dialogBox ; 
    //输出的内容以及说话者的名字
    public Text dialogText , nameText ; 

    [TextArea(1,3)]
    public string[] dialogLines ; //对话框输出内容
    [SerializeField] private int currentLine ; //实时追踪是行，哪个元素在输出

    //public string nameLines ; //说话者

    [SerializeField]private Animator animator;


    void Update()
    {
        //当对话框显示的时候，才会响应换页的按键
        if(dialogBox.activeInHierarchy)
        {
        
        
        if(Input.GetKeyDown(KeyCode.T))
        {
            currentLine ++ ; 
            if(currentLine < dialogLines.Length)
            {
                currentLine=0;
                CheckName(); 
                dialogText.text = dialogLines[currentLine]+"(按T继续)" ;
            }
            else
            {
                currentLine = 0 ; 
                dialogBox.SetActive(false);
                animator.Play("Hide");
                PlayerControl.GetInstance().canMove = true ;
            } 

        }
       }
    }

    public void ShowDialog(string[] _newline , bool _hasName){
        dialogLines = _newline ; 
        currentLine = 0 ;

        CheckName(); //检测首句是否是名字

        dialogText.text = dialogLines[currentLine] ;
        animator.Play("Show");

        nameText.gameObject.SetActive(_hasName);//没有名字的物体就不显示nameText了
        
        PlayerControl.GetInstance().canMove = false ; //限制玩家在对话状态不可移动
    }

    private void CheckName(){
        //检测该行是否是“代表玩家名字”的字符行
        //实现途径是利用StartWith来进行判断，通过检测字符串的开头得到对应的布尔值
        if(dialogLines[currentLine].StartsWith("n-")){
            //将对应名字的文本框的文本，传递给UI中的NameText
            nameText.text = dialogLines[currentLine].Replace("n-",""); //将前文的n-替换掉，从而得到正确的名字显示 
            currentLine ++ ;
        }
    } 

}
