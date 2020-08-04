using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnabler : MonoBehaviour
{
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
        if (other.tag == "Bullet")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                if (hit.transform.gameObject.GetComponent<PowerLine>() != null && hit.transform.gameObject.GetComponent<PowerLine>().SequenceNumber == 1)
                {
                    hit.transform.gameObject.GetComponent<PowerLine>().StartCheck();
                    hit.transform.gameObject.GetComponent<PowerLine>().charged = true;
                }
            }
        }
            
    }
}
