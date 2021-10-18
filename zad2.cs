using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class zad2 : MonoBehaviour
{   public float speed, cubePosition, cubeStartPosition, tmp;
    public bool go;
    Rigidbody rb;
    public Transform cubeTransform;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {   
        
        tmp = Math.Abs(cubeStartPosition - cubeTransform.position.x);

        if (tmp < 0.1)
        {
            go = true;
        }
        else if (tmp > 10.1)
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