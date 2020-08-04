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

    private void Start()
    {
        objp = GetComponentInParent<ObjectPush>();
        if(objp == null)
        {
            Debug.LogError("No object push reference");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && objp.newpos == Vector3.zero)
        {
            if(north == true)
            {
                objp.newpos = objp.transform.position - (objp.transform.forward * objp.transform.localScale.x);
            }
            if (south == true)
            {
                objp.newpos = objp.transform.position + (objp.transform.forward * objp.transform.localScale.x);
            }
            if (east == true)
            {
                objp.newpos = objp.transform.position - (objp.transform.right * objp.transform.localScale.x);
            }
            if (west == true)
            {
                objp.newpos = objp.transform.position + (objp.transform.right * objp.transform.localScale.x);
            }
        }
        if(other.tag == "Bullet" && objp.newpos == Vector3.zero)
        {
            if(north == true)
            {
                objp.newpos = objp.transform.position + (objp.transform.forward * objp.transform.localScale.x);
            }
            if (south == true)
            {
                objp.newpos = objp.transform.position - (objp.transform.forward * objp.transform.localScale.x);
            }
            if (east == true)
            {
                objp.newpos = objp.transform.position + (objp.transform.right * objp.transform.localScale.x);
            }
            if (west == true)
            {
                objp.newpos = objp.transform.position - (objp.transform.right * objp.transform.localScale.x);
            }
        }
    }
}
