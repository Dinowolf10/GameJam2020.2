using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Moves player based on user input
    /// </summary>
    public void CalculateMovement()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movement = playerInput.normalized * speed;
    }
}
