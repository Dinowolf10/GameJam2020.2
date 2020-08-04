using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public bool lookingAtPlayer = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.transform.parent.GetComponent<EnemyMovement>().MoveTowardsPlayer(other.transform);

            lookingAtPlayer = true;
        }

        else lookingAtPlayer = false;
    }
}
