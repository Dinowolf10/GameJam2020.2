using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 otherTeleporter;

    private void OnEnable()
    {
        FindOtherTeleporter();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            StartCoroutine("Teleport");
        }
    }

    private IEnumerator Teleport()
    {
        CharacterController cc = FindObjectOfType<CharacterController>();

        yield return new WaitForSeconds(.25f);

        cc.enabled = false;

        Debug.Log("Teleporting");

        GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(otherTeleporter.x -1.5f, 1.08f, otherTeleporter.z);

        yield return new WaitForSeconds(.50f);

        cc.enabled = true;

        yield break;
    }

    private void FindOtherTeleporter()
    {
        if (this.name == "Teleporter")
        {
            otherTeleporter = GameObject.Find("Teleporter (1)").GetComponent<Transform>().position;
        }
        else
        {
            otherTeleporter = GameObject.Find("Teleporter").GetComponent<Transform>().position;
        }
    }
}
