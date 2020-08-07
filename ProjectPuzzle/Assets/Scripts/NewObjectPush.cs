﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectPush : MonoBehaviour
{

    private Vector3 speed;
    private float time = .2f;

    Vector3 posToMoveTo;
    bool activelyMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activelyMoving == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, posToMoveTo, ref speed, time);
            if(transform.position == posToMoveTo)
            {
                activelyMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger");

        //if player collides or bullet from player collides
        if (other.transform.tag == "Player" || (other.transform.tag == "Bullet" && other.transform.GetComponent<Bullet>().firedBy == "Player"))
        {

            print("move me");

            Vector3 heading = other.transform.position - transform.position;

            //get which main direction is
            if(Mathf.Abs(heading.x) > Mathf.Abs(heading.z))
            {
                if(heading.x > 0)
                {
                    heading = new Vector3(1, 0, 0);
                }
                else
                {
                    heading = new Vector3(-1, 0, 0);
                }
            }
            else
            {
                if (heading.z > 0)
                {
                    heading = new Vector3(0, 0, 1);
                }
                else
                {
                    heading = new Vector3(0, 0, -1);
                }

            }

            //get whether to move towards or away from
            if (other.transform.tag == "Player")
            {
                posToMoveTo = transform.position - (heading * transform.localScale.x);
            }
            else
            {
                posToMoveTo = transform.position + (heading * transform.localScale.x);
            }


            //check if pos is free
            float sphereRad = transform.localScale.x / 2 - .001f;
            
            if(!Physics.CheckSphere(posToMoveTo, sphereRad))
            {
                activelyMoving = true;
                transform.position = Vector3.SmoothDamp(transform.position, posToMoveTo, ref speed, time);
            }          

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        print("collision");

        //if player collides or bullet from player collides
        if(collision.transform.tag == "Player" || (collision.transform.tag == "Bullet" && collision.transform.GetComponent<Bullet>().firedBy == "Player" ))
        {

            Vector3 hit = collision.contacts[0].normal;
            Vector3 posToMoveTo = transform.position + (hit * transform.localScale.x);
            transform.position = Vector3.SmoothDamp(transform.position, posToMoveTo, ref speed, time);
        }
    }
    

}