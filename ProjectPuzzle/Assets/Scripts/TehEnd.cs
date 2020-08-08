using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TehEnd : MonoBehaviour
{
    public Animator anim;
    [Space(10)]
    public GameObject EndLevel;
    public GameObject FirstLevel;
    public GameObject FinalStopper;
    public GameObject ExitDoor;
    [Space(10)]
    public Transform Player;
    public Vector3 MiddleofFirstLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("func1",.5f);
            Invoke("func1point5", 10f);
            Invoke("func2", 14f);
            Invoke("func3", 14.5f);
        }
    }
    void func1()
    {
        anim.Play("Event");

    }
    void func1point5()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/rewindTeleport");
    }
    void func2()
    {
        EndLevel.SetActive(false);
        FirstLevel.SetActive(true);
        FinalStopper.SetActive(true);
        ExitDoor.SetActive(false);

        Player.GetComponent<PlayerController>().enabled = false;
        Player.position = MiddleofFirstLevel;
    }
    void func3()
    {
        Player.GetComponent<PlayerController>().enabled = true;
        CancelInvoke();
    }
}
