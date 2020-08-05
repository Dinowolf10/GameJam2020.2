using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSceneChange : MonoBehaviour
{

    public bool changeOnStart = true;

    public string newScene;

    // Start is called before the first frame update
    void Start()
    {
        if (changeOnStart)
        {
            SceneController.instance.ChangeScene(newScene);
        } 
    }

}
