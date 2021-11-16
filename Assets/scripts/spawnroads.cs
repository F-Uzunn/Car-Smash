using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class spawnroads : MonoBehaviour
{

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    int whatToSpawn;
    public bool spawn = true;

    void Start()
    {
        if (!GameController.Instance.isGameFinished)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        for (int i = 100; i < 705; i += 100)
        {
            if (i < 700)
            {
                whatToSpawn = UnityEngine.Random.Range(1, 7);
                switch (whatToSpawn)
                {
                    case 1:
                        Instantiate(prefab1, transform.position = new Vector3(i, 0, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(prefab2, transform.position = new Vector3(i, 0, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(prefab3, transform.position = new Vector3(i, 0, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(prefab4, transform.position = new Vector3(i, 0, 0), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(prefab5, transform.position = new Vector3(i, 0, 0), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(prefab6, transform.position = new Vector3(i, 0, 0), Quaternion.identity);
                        break;
                }
            }
            
            else
            {
               
            }
        }
    }
}