using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private float shootTimer = 2f;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Keeps track of the cooldown between each enemy shot
    /// </summary>
    public void ShotCooldown()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else if (shootTimer <= 0)
        {
            if (firePoint == null)
            {
                transform.Find("FirePoint");
            }

            Shoot();

            shootTimer = 2f;
        }
    }

    /// <summary>
    /// Instantiates a bullet
    /// </summary>
    public void Shoot()
    {
        transform.GetComponent<EnemyMovement>().StartCoroutine("EnemyAttacking");

        // Instantiates a bullet and sets firedBy variable to enemy
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().firedBy = "Enemy";
        var rotation = bullet.GetComponent<Transform>().rotation.eulerAngles;
        rotation.z = -90f;
        bullet.GetComponent<Transform>().rotation = Quaternion.Euler(rotation);


        // Sound file
        FMODUnity.RuntimeManager.PlayOneShot("event:/Weapons/enemyFire");
    }
}
