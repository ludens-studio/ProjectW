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

    private int skipStep = 0 ; //计算跳过的步骤，来实现长按跳过
    private float theTime1 = 0 ; //短按的瞬间计时
    private float theTime2  = 0 ; //长按的时候持续计时

    [Header("长按跳过设置")]
    public float skipTime = 2 ; //长按跳过的时间判定
    private bool isSkip ;  

    private bool textEffectController = false;

    private void Start()
    {
        textUI.text = theTexts[currentLine] ; 
        sumOfText = theTexts.Count ;  
        isSkip = false ;
    }
    private void Update()
    {
        if(textEffectController)
            TextColorEffect();
        ReadText();
        Skip();
    }

    private void ReadText(){
        //进行文本阅读的方法
        if(Input.GetKeyDown(KeyCode.T) && currentLine != sumOfText-1){
            theTime1 += Time.deltaTime ; 
            Debug.Log("TIME 1 : --"+theTime1);

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
                TotheScene("艾伦房间");
            }
        }

    }

    private void TotheScene(string _scene){ 
        SceneManager.LoadScene(_scene);
    }

    private void Skip(){
        //长按T跳过对话
        if(Input.GetKey(KeyCode.T)){
            textEffectController = true;
            textUI.color = Color.white;
            theTime2 += Time.deltaTime ; 
            Debug.Log("t2 = "+theTime2);
        }

        if((theTime2-theTime1) >= skipTime  && isSkip == false) {
            Debug.Log("S-K-I-P!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            isSkip = true ;
            currentLine = sumOfText-2 ;
            textUI.text = theTexts[currentLine];

            if(currentLine == sumOfText-1){
                Debug.Log("对话结束");
                TotheScene("艾伦房间");
            }
        }       
    }

    public void TextColorEffect(){
        textUI.color = Color.Lerp(textUI.color,new Color(1,1,1,0),0.5f*Time.deltaTime);
    }

}
