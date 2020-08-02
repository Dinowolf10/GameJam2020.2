using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private bool fired = false;

    // Update is called once per frame
    void Update()
    {
        // If the bullet has not been fired, fires the bullet
        if (!fired)
        {
            // Adds a force to the bullet based on the bullet speed
            this.transform.GetComponent<Rigidbody>().AddForce(this.transform.forward * bulletSpeed, ForceMode.Impulse);

            // Sets fired to true
            fired = true;
        }
        
    }
}
