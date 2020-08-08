using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSceneChange : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneController.instance.ChangeScene(sceneName);
        }
    }
}
