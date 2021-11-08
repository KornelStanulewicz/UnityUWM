using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBox : MonoBehaviour
{

    public float speed, cubePosition, cubeStartPosition, tmp;
    public bool go;

    public bool isRunning;
    Rigidbody rb;
    public Transform cubeTransform;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        cubeTransform = this.gameObject.GetComponent<Transform>();
        speed = 2f;
        go = true;
    }
    void Start()
    {
        cubeStartPosition = cubeTransform.position.x;
    }

    void Update()
    {
        if (isRunning)
            {
                tmp = Math.Abs(cubeStartPosition - cubeTransform.position.x);

            if (tmp < 0.1)
            {
                go = true;
            }
            else if (tmp > 4.1)
            {
                go = false;
            }

            if (go == true)
            {
                rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            }
            else if (go == false)
            {
                rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            isRunning = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            isRunning = false;
        }
    }
}