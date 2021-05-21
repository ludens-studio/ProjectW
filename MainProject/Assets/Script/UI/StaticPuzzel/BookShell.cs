using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShell : MonoBehaviour
{
    public bool solved=false;
     void Start()
    {
        GameManager.GetInstance().StartPlot(PlotEvent.ENTER_BOOKSHEL);
        GameManager.GetInstance().EndShellPuzzel+=Solve;
    }

     void OnDisable()
    {
       if(!solved) GameManager.GetInstance().StartPlot(PlotEvent.EXIT_BOOKSHEL);    
    }

    void Solve(){solved=true;}
}
