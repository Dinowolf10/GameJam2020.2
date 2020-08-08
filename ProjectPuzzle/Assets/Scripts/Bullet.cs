using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private bool fired = false;

    [SerializeField]
    private float lifeSpan = 1f;

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
        else if(other.tag == "Enemy" && firedBy == "Player")
        {
            other.GetComponent<EnemyMovement>().health--;

            if (other.GetComponent<EnemyMovement>().health >= 1)
            {
                other.GetComponent<EnemyMovement>().StartCoroutine("EnemyAttacked");
            }

            // Sound file
            FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/enemyHurt");

            Destroy(this.gameObject);
        }
        else if (other.gameObject.name == "Player" && firedBy == "Enemy")
        {
            other.GetComponent<PlayerController>().TakeDamage(1);

            // Sound file
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/playerhurt");

            Destroy(this.gameObject);
        }
        else if (other.gameObject.name == "Player")
        {

        }
        else if (other.tag == "Destructible")
        {
            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }
        else if (other.tag == "PatternObject" && firedBy == "Player")
        {
            other.GetComponent<PatternObject>().NotifyHit();

            Destroy(this.gameObject);
        }
        else if(other.tag == "EventsTrigger")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
