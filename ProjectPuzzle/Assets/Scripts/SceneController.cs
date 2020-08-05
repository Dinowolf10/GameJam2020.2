using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void AddScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void CloseScene(string sceneName)
    {
        if(sceneName == GameController.instance.pauseMenuName)
        {
            GameController.instance.PauseMenuClosed();
        }
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
