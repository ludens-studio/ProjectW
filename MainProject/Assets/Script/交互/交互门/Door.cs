using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class Door : MonoBehaviour
{
    [Header("门的基本属性")]
    public string doorNum ;
    public bool doorOpen ; 

    [Header("这个门通向哪")]
   // public int Goto_Num ;   //数字模式和字符串模式二选一
    public string Goto_String ; 
    public bool canMove ; 
    private void Update()
    {
        UpdateDoorData();
        CheckDoorData();
        
    }

    private void UpdateDoorData(){
        //读取键值对数据，更新门的状态
        if(PlayerPrefs.GetInt(doorNum) == 1){
            doorOpen = true; 
            Debug.Log("Door "+doorNum+doorOpen);
        }else if(PlayerPrefs.GetInt(doorNum) == 0){
            doorOpen = false;
            Debug.Log("Door "+doorNum+doorOpen);
        }
    }

    private void CheckDoorData(){
        //针对情况发出反应
        this.gameObject.SetActive(doorOpen);
        canMove = doorOpen ;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(doorOpen == true && Input.GetKeyDown(KeyCode.F)){
                InteractiveManager.GetInstance().ChangeSence(Goto_String);
            }
        }
    }

}
