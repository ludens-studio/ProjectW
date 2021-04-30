using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private bool isOpen = false;
    [SerializeReference] private GameObject menuPanel;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowPanel();
    }

    public void ShowPanel()
    {
        if (isOpen)
        {
            isOpen = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
        }

        menuPanel.SetActive(isOpen);
    }
}
