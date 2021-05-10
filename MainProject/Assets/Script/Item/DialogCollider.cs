using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCollider : MonoBehaviour
{
    //触碰式对话框通用
    public GameObject Dialog ; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Dialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
        Dialog.SetActive(false);
        }
    }


}