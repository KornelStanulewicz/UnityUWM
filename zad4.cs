using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{
    public GameObject Cube;
    private float randomX, randomeY, randomeZ;
    List<Vector3> listOfVector = new List<Vector3>();

    void Update()
    {
        for(int i=0; i <= 9; i++)
        {
            Spawner();
        }
    }

    void Spawner()
    {
        Vector3 vector3;

        randomX = Random.Range(-4.5f, 4.5f);
        randomeY = Random.Range(1f, 10f);
        randomeZ = Random.Range(-4.5f, 4.5f);

        vector3 = new Vector3(randomX, randomeY, randomeZ);

        if (listOfVector.Count > 0)
            if (listOfVector.Exists(x => x == vector3))
            {
                randomX = Random.Range(-4.5f, 4.5f);
                randomeY = Random.Range(1f, 10f);
                randomeZ = Random.Range(-4.5f, 4.5f);

                vector3 = new Vector3(randomX, randomeY, randomeZ);

            }

        listOfVector.Add(vector3);

        Instantiate(Cube, new Vector3(randomX, randomeY, randomeZ), Quaternion.identity);
    }
}