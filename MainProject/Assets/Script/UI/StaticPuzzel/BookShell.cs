using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShell : MonoBehaviour
{
     void Start()
    {
        GameManager.GetInstance().StartPlot(PlotEvent.ENTER_BOOKSHEL);
    }
}
