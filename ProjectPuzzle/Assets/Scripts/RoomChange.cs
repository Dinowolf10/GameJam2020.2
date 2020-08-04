using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Animator UIFade;
    public float FadeDuration;
    public GameObject Cam1;
    public GameObject Cam2;
    public bool cantransition = true;

    // Start is called before the first frame update
    void Start()
    {
        if(Cam1 == null || Cam2 == null)
        {
            Debug.Log("door at " + transform.position + " is improperly set up");
        }
    }
    private void OnEnable()
    {
        cantransition = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && cantransition)
        {
            
            UIFade.Play("Faded");
            other.GetComponent<CharacterController>().enabled = false;
            Invoke("TransitionEnable", FadeDuration);
            Invoke("switchflick", FadeDuration * .6f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/transition");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        cantransition = true;
    }

    void switchflick()
    {
        if (Cam1.activeInHierarchy)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }

        else if (Cam2.activeInHierarchy)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
        cantransition = false;
    }

    void TransitionEnable()
    {
        CharacterController cc = FindObjectOfType<CharacterController>();
        cc.enabled = true;
    }
}
