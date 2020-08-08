using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool pauseMenuOpen = false;

    public string pauseMenuName = "PauseMenuScene";

    private void Awake()
    {

        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PauseMenuClosed()
    {
        Time.timeScale = 1;
        pauseMenuOpen = false;
    }

}
