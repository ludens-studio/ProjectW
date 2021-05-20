using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterGame : MonoBehaviour
{
    [SerializeReference]private Package package;
    public Text loadin; 
    private string textString="正在前往案发现场";
    private int dot=0;
    private float counter = 0;

    private void Awake()
    {
       for(int i=0;i<12;i++)
       {
           package.evidenceList[i]=null;
       }
    }

    void FixedUpdate()
    {
        if(loadin.gameObject.activeSelf)
        {
            counter += 0.02f;
            if(counter > 1f)
            {
               if(dot < 3) 
               {
                   dot++;
                   textString+=".";
               } 
               else 
               {
                   dot=0;
                   textString="正在前往案发现场";
               }
               counter=0;
            }
            loadin.text=textString;
        }
    }

    //开始游戏
    public void Play()
    {
        loadin.gameObject.SetActive(true);
        StartCoroutine("LoadGame");
    }

    //退出游戏
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadGame()
    {
        AsyncOperation operation= SceneManager.LoadSceneAsync("0开幕");
        while(!operation.isDone )
        {
            yield return null;
        }
    }
}
