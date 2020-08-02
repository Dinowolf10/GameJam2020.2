using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    /// <summary>
    /// Instantiates a bullet
    /// </summary>
    private void Shoot()
    {
        // Instantiates a bullet at the fire position
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Sound file for shooting
        FMODUnity.RuntimeManager.PlayOneShot("event:/Weapons/playerHandgun");
    }
}
