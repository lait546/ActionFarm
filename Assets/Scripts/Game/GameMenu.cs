using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    public bool isOpenMenu = false;

    public void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void SetActiveGameMenu(bool value)
    {
        isOpenMenu = value;
        if (value)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
