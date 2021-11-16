using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed = 2000f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.Instance.isGameEnded)
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
        else
        {
            speed = 0f;
        }

        if (!GameController.Instance.isGameFinished)
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            speed = 0f;
        }
    }

}
