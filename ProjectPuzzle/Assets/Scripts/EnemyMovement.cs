using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateRotation();
    }

    /// <summary>
    /// Calculates the angle for the enemy to look at, then sets its rotation to this angle
    /// </summary>
    private void CalculateRotation()
    {
        Transform playerPos = GameObject.Find("Player").GetComponent<Transform>();

        if (playerPos != null)
        {
            Vector2 direction = playerPos.position - this.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            this.GetComponent<Rigidbody2D>().rotation = angle;
        }
    }
}
