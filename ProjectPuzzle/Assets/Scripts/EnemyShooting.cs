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
        if (transform.Find("EnemyVision").GetComponent<EnemyVision>().lookingAtPlayer == true)
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
    }

    /// <summary>
    /// Instantiates a bullet
    /// </summary>
    public void Shoot()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Weapons/enemyFire");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
