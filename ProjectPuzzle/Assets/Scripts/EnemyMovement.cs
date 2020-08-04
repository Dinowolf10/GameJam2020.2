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
    void Update()
    {
        DetectPlayer();
    }

    /// <summary>
    /// Enemy looks at player
    /// </summary>
    public void Look()
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

    /// <summary>
    /// Uses a raycast to determine if nothing is blocking the vision of the enemy to the player
    /// </summary>
    public void DetectPlayer()
    {
        // Finds player gameobject and stores the transform
        Transform playerPos = GameObject.Find("Player").GetComponent<Transform>();
        
        if (playerPos != null)
        {
            Vector3 directionToPlayer = (playerPos.position - this.transform.position).normalized;

            Vector3 maxVisionRange = transform.Find("EnemyVision").GetComponent<MeshCollider>().bounds.max;

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, directionToPlayer, out hit, maxVisionRange.z * 2))
            {
                if (hit.collider != null)
                {
                    Debug.DrawLine(this.transform.position, hit.point, Color.green);

                    Debug.Log(hit.transform.gameObject.name);

                    if (hit.collider.gameObject.name == "Player")
                    {
                        transform.Find("EnemyVision").GetComponent<EnemyVision>().seesPlayer = true;
                    }
                    else
                    {
                        transform.Find("EnemyVision").GetComponent<EnemyVision>().seesPlayer = false;
                    }
                }
            }
        }
    }
}
