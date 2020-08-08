using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float coolDownTimer;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDownTimer <= 0)
        {
            if(GameController.instance == null || (GameController.instance != null && GameController.instance.pauseMenuOpen == false))
            {
                Shoot();

                coolDownTimer = .35f;
            }
            
        }
        else if (coolDownTimer > 0)
        {
            anim.SetBool("isShooting", false);

            coolDownTimer -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Instantiates a bullet
    /// </summary>
    private void Shoot()
    {
        anim.SetBool("isShooting", true);

        // Instantiates a bullet at the fire position and sets the firedBy variable to player
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().firedBy = "Player";

        // Sound file for shooting
        FMODUnity.RuntimeManager.PlayOneShot("event:/Weapons/playerHandgun");
    }
}
