using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraControl : SingletonAutoMono<CameraControl>
{
    public static CameraControl instance ; 
    public List<Transform> target = new List<Transform>() ; // 注意第一位一位（下标0）总是Player , 第二位以后是添加的相机点
    [Header("模式设置")]
    public  int cameraMode ; //0是固定，1是跟随，2是切换
    public int usingCamera ; //配合target数组设置的点

    [Header("渐变背景")]
    public Image blackImage ; 
    public float alpha ;

    private void Start()
    {
        target[0] = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        switch(cameraMode){
            case 0 :
                if(target[usingCamera]!= null)
                {
                transform.position = new Vector3(target[usingCamera].position.x,target[usingCamera].position.y,transform.position.z);
                }
                else{
                    Debug.Log("the target is not set!");
                }
                break;
            case 1 :
            transform.position = new Vector3(target[0].position.x,target[0].position.y,transform.position.z);
            break ; 

            case 3 :
            transform.position = new Vector3(target[usingCamera].position.x,target[usingCamera].position.y,transform.position.z);
            break ;

        }   
    }

    public void CameraFade(){
        int stage = 0 ;
        if(stage == 0){
            FadeIn();//调用FadeIn
            stage = 1 ;
            Debug.Log("Effect 1 ");
        }

        // if(stage == 1){
        //     FadeOut();
        //     Debug.Log("Effect 2 ");
        // }
    }

    public void FadeIn(){
        alpha = 1 ;
        bool ischange = true ; 

        while(ischange){
            alpha -= Time.deltaTime*0.001f ; 
            blackImage.color = new Color(0,0,0,alpha);
            ischange = false ;
        }
    }

    public void FadeOut(){
        alpha = 0 ;
        bool ischange = true ;

        while(ischange){
            alpha += Time.deltaTime ; 
            blackImage.color = new Color(0,0,0,alpha);
            ischange = false ; 
        }
    }

}
