using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ; 

public class SceneDialogue : MonoBehaviour
{
    [Header("UI设置")]
    public Text textUI ;

    [Header("文本设置")]
    public List<string> theTexts = new List<string>() ;
    private string text = "";
    private  int sumOfText = 0 ;  //文本有多少行
    [Tooltip("在这里写文本哦")]
    public int currentLine = 0 ;  //当前行

    [Header("特殊设置")]

    [Tooltip("在哪行触发特殊事件，这里是获得成就")]
    public int specialLine ;
    
    [Tooltip("下一个场景的名字")]
    public string nextScene ; 

    private void Start()
    {
        textUI.text = theTexts[currentLine] ; 
        sumOfText = theTexts.Count ;  
    }
    private void Update()
    {
        ReadText();
    }

    private void ReadText(){
        //进行文本阅读的方法
        if(Input.GetKeyDown(KeyCode.T) && currentLine != sumOfText-1){
            Debug.Log("下一条");
            currentLine++ ; 

            //正常化换行符
            theTexts[currentLine] = theTexts[currentLine].Replace("\\n", "\n");

            textUI.text = theTexts[currentLine];

            //如果到了某段特殊的对话，则执行一些特殊的语句
            if(currentLine == specialLine){
                Debug.Log("特殊对话");
                ShowTips.GetInstance().SetTips("获得成就","耐心是一种品质");
                ShowTips.GetInstance().OpenTips();
            }

            if(currentLine == sumOfText-1){
                Debug.Log("对话结束");
                TotheScene(nextScene);
            }
        }

    }

    private void TotheScene(string _scene){ 
        SceneManager.LoadScene(_scene);
    }



}
