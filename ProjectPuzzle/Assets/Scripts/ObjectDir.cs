using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDir : MonoBehaviour
{
    public bool north;
    public bool south;
    public bool east;
    public bool west;

    private ObjectPush objp;
    public GameObject opposite;
    public bool canPush;

    private void Start()
    {
        objp = GetComponentInParent<ObjectPush>();
        if(objp == null)
        {
            Debug.LogError("No object push reference");
        }
    }
    private void OnEnable()
    {
        canPush = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && objp.newpos == Vector3.zero && canPush == true)
        {
            if(north == true)
            {
               DirSet(-objp.transform.forward);
            }
            if (south == true)
            {
                DirSet(objp.transform.forward);
            }
            if (east == true)
            {
                DirSet(-objp.transform.right);
            }
            if (west == true)
            {
                DirSet(objp.transform.right);
            }
        }
        else if(other.tag == "Bullet" && objp.newpos == Vector3.zero)
        {
            if(north == true)
            {
                DirSet(objp.transform.forward);
            }
            if (south == true)
            {
                DirSet(-objp.transform.forward);
            }
            if (east == true)
            {
                DirSet(objp.transform.right);
            }
            if (west == true)
            {
                DirSet(-objp.transform.right);
            }
        }
        else
        {
            opposite.GetComponent<ObjectDir>().canPush = false;
        }
    }

    void DirSet(Vector3 dir)
    {
        objp.newpos = objp.transform.position + (dir * objp.transform.localScale.x);
    }

    
}
