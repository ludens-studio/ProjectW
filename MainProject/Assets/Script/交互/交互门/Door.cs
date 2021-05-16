using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class Door : MonoBehaviour
{
    [Header("门的基本属性")]
    public bool doorOpen ; 

    public bool doorEntry=false;

    [Header("这个门通向哪")]
   // public int Goto_Num ;   //数字模式和字符串模式二选一
    public Transform target ; 

    private Transform player;
    

    void Start()
    {
        player=PlayerControl.GetInstance().gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if(doorEntry&&Input.GetKeyDown(KeyCode.F)) Move();
    }

    public void Move()
    {
        PlayerControl.GetInstance().Pause();
        player.position=new Vector3(target.position.x,target.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            doorEntry=true;
            InteractiveManager.GetInstance().CurrentDoor=this;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
         if(other.gameObject.tag == "Player")
        {
            doorEntry=false;
            InteractiveManager.GetInstance().CurrentDoor=null;
        }
    }

    public void EnterScene()
    {

    }
}
