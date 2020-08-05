using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public bool seesPlayer = false;

    public bool playerInCollider;

    private void OnTriggerStay(Collider other)
    {
        // If the enemy vision collides with the player and the enemy "sees" the player
        if (other.gameObject.name == "Player" && seesPlayer == true)
        {
            // Enemy looks at the player
            this.transform.parent.GetComponent<EnemyMovement>().Look();

            // Enemy moves towards the player
            this.transform.parent.GetComponent<EnemyMovement>().MoveTowardsPlayer(other.transform);

            // Enemy shoots at the player
            this.transform.parent.GetComponent<EnemyShooting>().ShotCooldown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInCollider = false;
        }
    }
}
