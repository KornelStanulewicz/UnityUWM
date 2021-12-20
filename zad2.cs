using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float speed = 2f, distance = 5f;
    public float startPosition, endPosition;
    public bool go, back;

    Vector3 movement;
    Rigidbody rb;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        endPosition = transform.position.x + distance;
        startPosition = transform.position.x;
    }

    void Update()
    {
        if (transform.position.x >= endPosition)
        {
            go = false;
            back = true;
        }

        if (back && transform.position.x <= startPosition)
        {
            back = false;
        }

        if (go)
        {
            movement.x = speed;
            movement.y = 0;
            movement.z = 0;
        }

        if (back)
        {
            movement.x = -speed;
            movement.y = 0;
            movement.z = 0;
        }
    }

    private void FixedUpdate()
    {
        if (go || back)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            go = true;
        }
    }
}