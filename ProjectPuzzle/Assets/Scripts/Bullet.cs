using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private bool fired = false;

    [SerializeField]
    private Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        // If the bullet has not been fired, fires the bullet
        if (!fired)
        {
            // Adds a force to the bullet based on the bullet speed
            this.transform.GetComponent<Rigidbody2D>().AddForce(this.transform.up * bulletSpeed, ForceMode2D.Impulse);

            fired = true;
        }
        
    }
}
