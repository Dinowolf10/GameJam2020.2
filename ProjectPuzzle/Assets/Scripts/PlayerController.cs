﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;

    public int health = 3;

    public float speed;

    [SerializeField]
    private Vector3 spawnPoint;

    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        playerController = this.GetComponent<CharacterController>();

        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Look();

        if (cam.gameObject.activeInHierarchy == false)
        {
            cam = FindObjectOfType<Camera>();
        }

        if (health <= 0)
        {
            transform.position = spawnPoint;
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

        playerController.Move(movement * speed * Time.deltaTime);

        // Keeps player on the ground
        transform.position = new Vector3(transform.position.x, 1.08f, transform.position.z);

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
}
