using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardButton : MonoBehaviour
{
    public void OpenMenu(UiBoard menu)
    { 
        menu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu(UiBoard menu)
    {
        Time.timeScale = 1;
        menu .gameObject.SetActive(false);
    }
}
