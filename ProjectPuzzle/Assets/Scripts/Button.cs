using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool activated = false;

    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 
        if (counter > 0)
        {
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                // Sound file
                FMODUnity.RuntimeManager.PlayOneShot("event:/Puzzle mechanics/Node off");

                activated = false;
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (activated == false)
            {
                // Sound file
                FMODUnity.RuntimeManager.PlayOneShot("event:/Puzzle mechanics/Node on");

                activated = true;

                counter = 5f;
            }
        }
    }
}
