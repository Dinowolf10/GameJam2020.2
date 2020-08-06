using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternObject : MonoBehaviour
{
    [SerializeField]
    private PatternManager manager;

    private bool isRecording = false;

    public void NotifyHit()
    {
        if (isRecording)
        {
            manager.GetHit(gameObject);
        }
    }

    public void StartRecording()
    {
        isRecording = true;
    }

    public void StopRecording()
    {
        isRecording = false;
    }


}
