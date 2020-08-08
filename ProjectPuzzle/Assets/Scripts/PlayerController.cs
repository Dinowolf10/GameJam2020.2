using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;

    public int health = 3;

    public int maxHealth = 3;

    public float speed;

    public Animator anim;

    public bool hasDied = false;

    [SerializeField]
    private Vector3 spawnPoint;

    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        playerController = this.GetComponent<CharacterController>();

        anim = GetComponent<Animator>();

        if (cam == null)
        {
            cam = Camera.main;
        }

        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.enabled == true)
        {
            Move();

            Look();
        }

        if (cam.gameObject.activeInHierarchy == false)
        {
            cam = FindObjectOfType<Camera>();
        }

        if (health <= 0 && transform.position != spawnPoint)
        {
            if (hasDied == false)
            {
                hasDied = true;

                playerController.enabled = false;

                StartCoroutine("Respawn");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameController.instance.pauseMenuOpen == false)
            {
                GameController.instance.pauseMenuOpen = true;
                SceneController.instance.AddScene(GameController.instance.pauseMenuName);
            }
        }
    }

    private void FixedUpdate()
    {

    }

    /// <summary>
    /// Moves player based on user input
    /// </summary>
    public void Move()
    {
        // Gets user inpt from the horizontal and vertical axis
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (movement != Vector3.zero && movement.x < 0)
        {
            anim.SetBool("isWalkingLeft", true);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalking", false);
        }
        else if (movement != Vector3.zero && movement.x > 0)
        {
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("isWalking", false);
        }
        else if (movement != Vector3.zero)
        {
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalking", false);
        }

        playerController.Move(movement * speed * Time.deltaTime);

        // Keeps player on the ground
        transform.position = new Vector3(transform.position.x, -0.06f, transform.position.z);

        /*if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }*/
    }
    
    /// <summary>
    /// Sets rotation of the player using a raycast to determine the mouse position
    /// </summary>
    public void Look()
    {
        // Shoots a ray out to the mouse position
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        // Creates a ground plane
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        // Used to store the ray length
        float rayLength;

        // Determines the length of the ray to the ground
        if (ground.Raycast(camRay, out rayLength))
        {
            // Stores the point the player should look at
            Vector3 lookPosition = camRay.GetPoint(rayLength);

            // Player looks at the point, keep y position the same so the player doesnt look at the ground
            transform.LookAt(new Vector3(lookPosition.x, this.transform.position.y, lookPosition.z));
        }
    }

    private IEnumerator Respawn()
    {
        // Sound file
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/playerDies");

        anim.SetBool("isDead", true);

        yield return new WaitForSeconds(5f);

        anim.SetBool("isDead", false);

        transform.position = spawnPoint;

        health = maxHealth;

        hasDied = false;

        playerController.enabled = true;
    }
}
