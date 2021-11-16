using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finished : MonoBehaviour
{
    public GameObject[] arabalar;
    public GameObject LevelCompleted;
   

    // Update is called once per frame

    private void Start()
    {
        
        LevelCompleted.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "RampCar")
        {
            GameController.Instance.isGameEnded = true;
           

        }

        if (collision.gameObject.tag == "DestroyCar")
        {
            GameController.Instance.isGameEnded = true;
          

        }
    }
}
