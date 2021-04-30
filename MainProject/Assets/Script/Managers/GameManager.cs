using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class GameManager : SingletonMono<GameManager>
{
    public static GameManager instance ;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //设置instance
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
   
}
