using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveItem : MonoBehaviour
{    private bool canUse = false ; //是否处于可交互状态
    [Header("是否只能交互一次？")]
    public bool UseOnce ; //如果设置为true，那么只能被交互一次

    [Header("交互模式")]
    public int mode = 0 ; //详见Mgr或者文档，0代表没有选择模式

    void Start(){
        if(mode == 0){
            Debug.Log("Error , No Mode");
        }
    }

    void Update()
    {
        if(canUse){
            //如果按下交互键（这里是F）会执行进行交互的方法
            if(Input.GetKeyDown(KeyCode.F)){
                Debug.Log("交互");
                InteractiveManager.instance.UsingIt(mode);
                canUse = false; //再把canUse设置为false，只有再次碰撞才能再次交互
                if(UseOnce){
                    Destroy(this); //这里直接摧毁了
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //进入时
        if(other.tag == "Player"){
            Debug.Log("CanUse");
            InteractiveManager.instance.OpenTips();
            canUse = true ; 
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //退出时
        if(other.tag == "Player"){
            Debug.Log("Can`t Use");
            InteractiveManager.instance.CloseTips();
            canUse = true ; 
        }
    }
}
