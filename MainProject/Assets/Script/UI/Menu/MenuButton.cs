using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private bool isOpen = false;
    [SerializeReference] private GameObject menuPanel;
    [SerializeReference] private GameObject exitConfirm;
    [SerializeReference] private GameObject volumeControl;
    Stack<GameObject> PanelList = new Stack<GameObject>();


    // 防止鼠标外移
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowPanel();
    }

    public void ShowPanel()
    {
        // 底层面板打开时，按esc关闭
        if (isOpen)
        {
            PanelList.Peek().SetActive(false);
            PanelList.Pop();
            if(PanelList.Count == 0)
                isOpen = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        // 底层面板关闭时，按esc打开
        else
        {
            PanelList.Push(menuPanel);
            PanelList.Peek().SetActive(true);
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // 展示退出面板面板
    public void ShowExitConfirmPanel()
    {
        PanelList.Push(exitConfirm);
        PanelList.Peek().SetActive(true);
    }

    // 展示音量调节面板
    public void ShowVolumePanel()
    {
        PanelList.Push(volumeControl);
        PanelList.Peek().SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void BackGame()
    {
        PanelList.Peek().SetActive(false);
        PanelList.Pop();
        isOpen = false;
        Cursor.lockState = CursorLockMode.Confined;        
    }
}
