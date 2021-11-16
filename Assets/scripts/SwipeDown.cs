using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDown : MonoBehaviour
{
    public GameObject[] arabalar;
    public GameObject swipedown;


    // Update is called once per frame

    private void Start()
    {
        swipedown.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "RampCar")
        {
            swipedown.SetActive(true);
            Destroy(swipedown, 2f);
        }

        if (collision.gameObject.tag == "DestroyCar")
        {

            swipedown.SetActive(true);
            Destroy(swipedown, 2f);

        }
    }
}
