using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    Rigidbody rb;
    public List<Vector3> listOfWayPoints = new List<Vector3>();
    public float speed = 2f;
    public Vector3 startPosition, endPosition, movement;
    public int i, howManyElementsInList;
    public bool go = true, back = false, start;

    public Transform oldParent;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        i = 0;
        howManyElementsInList = listOfWayPoints.Count() - 1;
    }
    void Start()
    {
        startPosition = this.transform.position;
        endPosition = listOfWayPoints[i];
    }

    void FixedUpdate()
    {
        if (start)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            oldParent = other.gameObject.transform.parent;

            other.gameObject.transform.parent = transform;

            if (this.transform.position.x < endPosition.x || this.transform.position.y < endPosition.y || this.transform.position.z < endPosition.z)
            {
                if (startPosition.x != endPosition.x)
                    movement.x = speed;
                else
                    movement.x = 0;
                if (startPosition.y != endPosition.y)
                    movement.y = speed;
                else
                    movement.y = 0;
                if (startPosition.z != endPosition.z)
                    movement.z = speed;
                else
                    movement.z = 0;
            }
            if (this.transform.position.x >= endPosition.x || this.transform.position.y >= endPosition.y || this.transform.position.z >= endPosition.z)
            {
                if (i == 0)
                {
                    back = false;
                    go = true;
                    speed = Mathf.Abs(speed);
                }

                if (i == howManyElementsInList)
                {
                    go = false;
                    back = true;
                    speed = -speed;
                }

                if (go)
                {
                    startPosition = endPosition;
                    endPosition = listOfWayPoints[i + 1];
                }

                if (back)
                {
                    startPosition = endPosition;
                    endPosition = listOfWayPoints[i - 1];
                }
            }

            start = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = oldParent;
            start = false;
        }
    }
}
