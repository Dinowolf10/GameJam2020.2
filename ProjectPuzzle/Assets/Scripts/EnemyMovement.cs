using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.Find("EnemyVision").GetComponent<EnemyVision>().lookingAtPlayer == true)
        {
            Look();

            //MoveTowardsPlayer(GameObject.Find("Player").transform);
        }
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

    /// <summary>
    /// Enemy moves towards player
    /// </summary>
    public void MoveTowardsPlayer(Transform playerPos)
    {
        if (playerPos != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos.position, speed * Time.deltaTime);
        }
    }
}
