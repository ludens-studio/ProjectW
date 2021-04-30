using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private LinkedList<GameObject> logBullects = new LinkedList<GameObject>();
    private LinkedList<GameObject> battleBullets = new LinkedList<GameObject>();
    [SerializeReference] private GameObject logBullet;
    [SerializeReference] private GameObject battleBullet;
    [SerializeReference] private Transform logT;
    [SerializeReference] private Transform batT;

    private static BulletPool instance;

    private void Awake()
    {
        instance = this;
        for(int i=0;i<8;i++)
        {
            var tem = Instantiate(logBullet, logT);
            logBullects.AddFirst(tem);
        }

        for (int i = 0; i < 8; i++)
        {
            var tem = Instantiate(battleBullet, batT);
            battleBullets.AddFirst(tem);
        }
    }

    /// <summary>
    /// 获取子弹池子单例
    /// </summary>
    /// <returns></returns>
    public static BulletPool GetInstance() 
    {
        return instance; 
    }

}
