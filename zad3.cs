using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float speed, cubeStartPositionX, cubeStartPositionZ, tmpX, tmpZ;
    public bool go, rotate;
    Rigidbody rb;
    public Transform cubeTransform;
    public int direction;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        cubeTransform = this.gameObject.GetComponent<Transform>();
        speed = 2f;
        go = true;
        direction = 1;
    }

    void Start()
    {
        cubeStartPositionX = cubeTransform.position.x;
        cubeStartPositionZ = cubeTransform.position.z;
    }

    void Update()
    {
        tmpX = Math.Abs(cubeStartPositionX - cubeTransform.position.x);
        tmpZ = Math.Abs(cubeStartPositionZ - cubeTransform.position.z);
        if (tmpX > 10.1 || tmpZ > 10.1)
        {
            go = false;
            rotate = true;
        }

        if (go)
        {
            switch (direction)
            {
                case 1:
                    rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
                    break;
                case 2:
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
                    break;
                case 3:
                    rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
                    break;
                case 4:
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
                    break;
            }
        }

        if (rotate)
        {
            cubeTransform.Rotate(0, 90, 0);
            cubeStartPositionX = cubeTransform.position.x;
            cubeStartPositionZ = cubeTransform.position.z;
            if (direction <= 3)
                direction++;
            else
                direction = 1;
            rotate = false;
            go = true;
        }
    }
}