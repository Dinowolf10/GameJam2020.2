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
        Look();
    }

    /// <summary>
    /// Enemy looks at player
    /// </summary>
    private void Look()
    {
        // Finds player gameobject and stores the transform
        Transform playerPos = GameObject.Find("Player").GetComponent<Transform>();

        // If player is still alive, the enemy looks at the players position
        if (playerPos != null)
        {
            this.transform.LookAt(playerPos);
        }
    }
}
