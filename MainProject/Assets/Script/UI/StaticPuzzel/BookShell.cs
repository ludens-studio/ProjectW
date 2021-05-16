using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShell : MonoBehaviour
{
     void Start()
    {
        GameManager.GetInstance().StartSpeaking("进入书架");
    }
}
