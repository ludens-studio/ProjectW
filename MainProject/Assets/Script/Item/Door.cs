using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class Door : MonoBehaviour
{
    public Text doorDioLog ; 
    [Header("门的基本属性")]
    //门的种类编号，0是单向门，10是单向门(用来开的)，1是无锁门，2是有锁门
    public int doorType ;
    //门的编号，在单向门和有锁门中启动一一对应的作用
    public int doorNum ;

    void Update()
    {
        DioLogUpdate();
        if(Input.GetKeyDown(KeyCode.F)){
            PressedF();
        }
    }

    public void DioLogUpdate(){

        switch(doorType){
            case 0 : 
            doorDioLog.text = "从这一侧打不开" ;

            break ; 

            case 10 : 
            doorDioLog.text = "似乎可以从这一侧打开某扇门,要开启吗？" ;

            break ; 

            case 1 : 
            doorDioLog.text = "没有上锁的门，要打开吗" ;

            break ; 

            case 2 : 
            doorDioLog.text = "门锁上了，需要特定的钥匙" ;

            break ; 

        }
    }

    void PressedF(){
        switch(doorType){
            case 0 : 
            doorDioLog.text = "从这一侧打不开" ;
            break ; 

            case 10 :
            doorDioLog.text = "门被打开了" ;
            break ; 

            case 1 :
            doorDioLog.text = "请进" ;
            break ;

            case 2 :
            Debug.Log("确认钥匙正确");
            break ; 

        }
    }
}
