using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakSound : MonoBehaviour
{
    void OnDisable()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Puzzle mechanics/boulderBreak");
    }
}
