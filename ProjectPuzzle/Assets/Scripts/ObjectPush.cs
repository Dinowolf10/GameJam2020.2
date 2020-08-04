using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPush : MonoBehaviour
{
    public int placemoving;
    public Vector3 newpos;
    private Vector3 speed;
    public float time;

    float holdercal;
    private List<float> side = new List<float>();
    private List<float> distside = new List<float>();

    public float test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(newpos != Vector3.zero)
        {
            transform.position = Vector3.SmoothDamp(transform.position, newpos, ref speed, time);
        }
        if(newpos == transform.position)
        {
            newpos = Vector3.zero;
            Debug.Log("done");
        }
        if (newpos == Vector3.zero)
        {
            RaycastHit hit;
            if (Physics.SphereCast(new Ray(transform.position, transform.forward), transform.localScale.z * .80f, out hit, test))
            {
                if (hit.transform.tag == "Player")
                {
                    Debug.Log("Loksgd");
                    newpos = transform.position - (transform.forward * transform.localScale.x);
                }
            }
        }

    }

   
            //newpos = transform.position - (transform.forward * transform.localScale.x);
            //newpos = transform.position + (transform.forward * transform.localScale.x);
            //newpos = transform.position - (transform.right * transform.localScale.z);
            //newpos = transform.position + (transform.right * transform.localScale.z);

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
