using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogUIAction : MonoBehaviour
{
    [SerializeReference] private GameObject LogPanel;

    public void ShowPanel()
    {
        LogPanel.SetActive(!LogPanel.activeSelf);
    }
}
