using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class DiaLogManager : SingletonMono<DiaLogManager>
{
    public static DiaLogManager instance ;

    //对话框的UI
    public GameObject dialogBox ; 
    //输出的内容以及说话者的名字
    public Text dialogText , nameText ; 

    [TextArea(1,3)]
    public string[] dialogLines ; //对话框输出内容
    [SerializeField] private int currentLine ; //实时追踪是行，哪个元素在输出


    void Start()
    {
        dialogText.text = dialogLines[currentLine] ; 
    }
    void Update()
    {
        //当对话框显示的时候，才会响应换页的按键
        if(dialogBox.activeInHierarchy){
        //这里先设置按E切换
        if(Input.GetMouseButtonUp(0)){
            Debug.Log("2");
            currentLine ++ ; 
            if(currentLine < dialogLines.Length){
            Debug.Log("3");
            dialogText.text = dialogLines[currentLine] ;
            }else{
                currentLine = 0 ; 
                dialogBox.SetActive(false);

                PlayerControl.instance.canMove = true ;
            } 

        }
        }
    }

    public void ShowDialog(string[] _newline){
        dialogLines = _newline ; 
        currentLine = 0 ;
        dialogText.text = dialogLines[currentLine] ;
        dialogBox.SetActive(true);

        PlayerControl.instance.canMove = false ; //限制玩家在对话状态不可移动
    }
}
