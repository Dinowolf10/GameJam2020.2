using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnd : MonoBehaviour
{
    public GameObject DoorToOpen;

    // Start is called before the first frame update
    void Start()
    {
        if(DoorToOpen == null)
        {
            Debug.Log("Power End in " + transform.parent.transform.parent + " wont open anything");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChargeToLine()
    {
        if (DoorToOpen == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Puzzle mechanics/Door unlock");
        }
        DoorToOpen.SetActive(false);

    }
}
