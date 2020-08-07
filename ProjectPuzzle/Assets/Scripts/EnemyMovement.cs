using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int health = 2;

    public float speed;

    [SerializeField]
    private Vector3 spawnPoint;

    [SerializeField]
    private Quaternion startingRotation;

    [SerializeField]
    private bool resurrectStarted;

    void OnEnable()
    {
        spawnPoint = transform.position;

        startingRotation = this.transform.rotation;

        Debug.Log(startingRotation);
    }

    private void OnDisable()
    {
        transform.position = spawnPoint;

        transform.rotation = startingRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            DetectPlayer();

            //CheckForReturn();

            //CheckForRotation();
        }

        if (health <= 0)
        {
            if (!resurrectStarted)
            {
                // Sound file
                FMODUnity.RuntimeManager.PlayOneShot("event:/Enemies/enemyDies");

                StartCoroutine("Resurrect");

                resurrectStarted = true;
            }
        }
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

            if (Physics.Raycast(this.transform.position, directionToPlayer, out hit, maxVisionRange.z))
            {
                if (hit.collider != null)
                {
                    Debug.DrawLine(this.transform.position, hit.point, Color.green);

                    //Debug.Log(hit.transform.gameObject.name);

                    if (hit.collider.gameObject.name == "Player")
                    {
                        transform.Find("EnemyVision").GetComponent<EnemyVision>().seesPlayer = true;
                    }
                    else
                    {
                        transform.Find("EnemyVision").GetComponent<EnemyVision>().seesPlayer = false;

                        //this.transform.position = Vector3.MoveTowards(this.transform.position, spawnPoint, speed / 2 * Time.deltaTime);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Checks if enemy should move back to spawn point
    /// </summary>
    /*public void CheckForReturn()
    {
        if (this.transform.position != spawnPoint && transform.Find("EnemyVision").GetComponent<EnemyVision>().playerInCollider == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, spawnPoint, speed / 2 * Time.deltaTime);
        }
    }*/

    /// <summary>
    /// Checks if enemy is at spawn point and if their rotation needs to be reset
    /// </summary>
    /*public void CheckForRotation()
    {
        if (this.transform.position == spawnPoint)
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 180f, this.transform.rotation.z, this.transform.rotation.w);
        }
    }*/

    public IEnumerator Resurrect()
    {
        while (this.transform.position != spawnPoint)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, spawnPoint, .001f);

            //Debug.Log("Moving");

            yield return null;
        }

        this.transform.rotation = startingRotation;

        health = 2;

        resurrectStarted = false;

        yield break;
    }
}
