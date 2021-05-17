using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraControl : SingletonMono<CameraControl>
{
    public static CameraControl instance ; 
    public List<Transform> target = new List<Transform>() ; // 注意第一位一位（下标0）总是Player , 第二位以后是添加的相机点
    [Header("模式设置")]
    public  int cameraMode ; //0是固定，1是跟随，2是切换
    public int usingCamera ; //配合target数组设置的点

    private InteractiveManager manager;


    [SerializeReference]private float offsetX;

    [SerializeReference]private float offsetY;

    private Animator animator;

    private void Start()
    {
        target.Add( PlayerControl.GetInstance().gameObject.GetComponent<Transform>());
        manager=InteractiveManager.GetInstance();
        animator=gameObject.GetComponent<Animator>();
    }


    private void Update()
    {
        switch(cameraMode)
        {
            case 0 :
                if(target[usingCamera]!= null)
                {
                transform.position = new Vector3(target[usingCamera].position.x+offsetX,offsetY,transform.position.z);
                }
                else{
                    Debug.Log("the target is not set!");
                }
                break;
            case 1 :
            transform.position = new Vector3(target[0].position.x,target[0].position.y,transform.position.z);
            break ; 

            case 2 :
            transform.position = new Vector3(target[usingCamera].position.x,target[usingCamera].position.y,transform.position.z);
            break ;

        }   
    }

    public void PlayEnterAnim()
    {
        if(animator!=null)
        {
            animator.Play("Move");
        }
        else Debug.Log("null");
    }

    public void Pause()
    {
        PlayerControl.GetInstance().Pause();
    }
    public void EnableMove()
    {
        PlayerControl.GetInstance().EnableMove();
    }

    public void Move()
    {
        InteractiveManager.GetInstance().CurrentDoor.Move();
    }

}
