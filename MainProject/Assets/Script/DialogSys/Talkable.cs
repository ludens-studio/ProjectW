using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    //通用的拥有对话属性的对象
    [SerializeField] private bool isEntered ; 

    [TextArea(1,3)]
    public string[] lines ; //每个人物自定义的对话

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            isEntered  = true ; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            if(other.CompareTag("Player")){
            isEntered  = false ; 
        }
    }

    private void Update()
    {
        if(isEntered && Input.GetKeyDown(KeyCode.F) && DiaLogManager.instance.dialogBox.activeInHierarchy == false ){
            DiaLogManager.instance.ShowDialog(lines);
        }
    }
}
