using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHearts : MonoBehaviour
{
    PlayerController PH;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    // Start is called before the first frame update
    void Start()
    {
        PH = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PH.health == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        if (PH.health == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        if (PH.health == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
        if (PH.health <= 0)
        {
            Heart1.SetActive(false);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
    }
}
