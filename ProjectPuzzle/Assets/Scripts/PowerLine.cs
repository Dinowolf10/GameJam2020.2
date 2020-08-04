using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    public int SequenceNumber;
    public bool charged;
    public bool IsEnd;

    // Start is called before the first frame update
    void Start()
    {
        if (SequenceNumber == 0)
        {
            charged = true;
            StartCheck();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (charged)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void StartCheck()
    {
        Invoke("Check", 1f);
    }

    void Check()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1f) && !IsEnd)
        {
            if (hit.transform.gameObject.GetComponent<PowerLine>() != null && hit.transform.gameObject.GetComponent<PowerLine>().SequenceNumber == SequenceNumber + 1)
            {
                hit.transform.gameObject.GetComponent<PowerLine>().StartCheck();
                hit.transform.gameObject.GetComponent<PowerLine>().charged = true;
            }
            else
            {
                PowerLine[] pl;
                pl = FindObjectsOfType<PowerLine>();
                for (int i = 0; i < pl.Length; i++)
                {
                    pl[i].charged = false;
                }
            }
        }

        else if(!IsEnd)
        {
            PowerLine[] pl;
            pl = FindObjectsOfType<PowerLine>();
            for (int i = 0; i < pl.Length; i++)
            {
                pl[i].charged = false;
            }
        }

        else if (Physics.Raycast(transform.position, transform.forward, out hit, 1f) && IsEnd)
        {
            if (hit.transform.gameObject.GetComponent<PowerEnd>() != null)
            {
                hit.transform.gameObject.GetComponent<PowerEnd>().ChargeToLine();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
