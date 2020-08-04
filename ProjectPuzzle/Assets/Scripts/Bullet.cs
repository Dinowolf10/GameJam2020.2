using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private bool fired = false;

    [SerializeField]
    private float lifeSpan = 2f;

    public string firedBy;

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

        if (lifeSpan > 0)
        {
            lifeSpan -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnemyVision")
        {

        }
        else if (other.gameObject.name == "Player")
        {

        }
        else if (other.tag == "Destructible")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
