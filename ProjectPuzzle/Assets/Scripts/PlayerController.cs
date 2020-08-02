using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 movement;

    [SerializeField]
    private Camera cam;

    private Vector3 mousePos3D;

    private Vector2 mousePos2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        CalculateMousePos();
    }

    private void FixedUpdate()
    {
        Move();

        Look();
    }

    /// <summary>
    /// Calculates player movement based on user input
    /// </summary>
    public void CalculateMovement()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movement = playerInput.normalized * speed;
    }

    /// <summary>
    /// Calculates the mouse position
    /// </summary>
    public void CalculateMousePos()
    {
        // Gets the mouse position and changez z to 10 due to camera being 10 units away
        mousePos3D = Input.mousePosition;
        mousePos3D.z = 10;

        // Converts mouse position from pixels to world units
        mousePos2D = cam.ScreenToWorldPoint(mousePos3D);
    }

    /// <summary>
    /// Moves player
    /// </summary>
    public void Move()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Sets rotation of player based on mouse position
    /// </summary>
    public void Look()
    {
        Vector2 direction = (mousePos2D - rb.position);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
