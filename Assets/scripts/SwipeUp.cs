using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeUp : MonoBehaviour
{
    public GameObject[] arabalar;
    public GameObject swipeup;


    // Update is called once per frame

    private void Start()
    {
        swipeup.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "RampCar")
        {
            swipeup.SetActive(true);
            Destroy(swipeup, 2f);
        }

        if (collision.gameObject.tag == "DestroyCar")
        {

            swipeup.SetActive(true);
            Destroy(swipeup, 2f);

        }
    }
}
