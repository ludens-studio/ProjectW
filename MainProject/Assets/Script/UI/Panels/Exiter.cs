using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exiter : MonoBehaviour
{
    public void Close()
    {
        StaticPanelMgr.GetInstance().LeavePanel();
    }
}
