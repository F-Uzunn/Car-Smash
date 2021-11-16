using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class spawnroadsEndless : MonoBehaviour
{
    int i = 0;
    int y = 100;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public bool spawn;
    int whatToSpawn;
    public float currentScore = 0;
    public float limit = 0;


    private void Start()
    {
        currentScore = 0;
        limit = 2000;
    }


    void Update()
    {
        if (GameController.Instance.Pause)
        {
            if (!GameController.Instance.PauseGame)
                currentScore++;

            if (currentScore > limit)
            {

                limit = limit + 2000;
                if (y >= 60)
                {
                    y = y - 5;
                }
            }
        }


        if (spawn)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
            spawn = false;
            i = i + y;
            Debug.Log("i=" + i);
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
            yield return new WaitForSeconds(3f);
            spawn = true;
    }
}