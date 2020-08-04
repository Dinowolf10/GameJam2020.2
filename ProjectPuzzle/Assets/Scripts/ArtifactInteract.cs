using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ArtifactInteract : MonoBehaviour
{
    public GameObject pickupText;
    public int artifactId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            pickupText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                Destroy(gameObject);
                pickupText.SetActive(false);

                // Sound file
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/artifact");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            pickupText.SetActive(false);
        }
    }

}
