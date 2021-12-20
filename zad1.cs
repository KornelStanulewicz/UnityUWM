using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    public bool start, go = true, back = false;
    public float distance = 5f, elevatorSpeed = 2f;
    public float startPosition, endPosition;

    public Transform oldParent;

    Vector3 movement;

    Rigidbody rb;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        endPosition = transform.position.x + distance;
        startPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        if (go && transform.position.x >= endPosition)
            start = false;

        if (back && transform.position.x <= startPosition)
            start = false;

        if (start)
        {
            rb.MovePosition(rb.position + movement * elevatorSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kolizja");

            oldParent = other.gameObject.transform.parent;

            other.gameObject.transform.parent = transform;

            if (transform.position.x >= endPosition)
            {
                back = true;
                go = false;
                movement.x = 0;
                movement.y = 0;
                movement.z = -elevatorSpeed;
            }

            if (transform.position.x <= startPosition)
            {
                go = true;
                back = false;
                movement.x = 0;
                movement.y = 0;
                movement.z = elevatorSpeed;
            }

            start = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Koniec kolizji");
            other.gameObject.transform.parent = oldParent;
            start = false;
        }
    }
}