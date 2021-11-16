using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRight : MonoBehaviour
{
    public GameObject[] arabalar;
    public GameObject swiperightsprite;


    // Update is called once per frame

    private void Start()
    {
        swiperightsprite.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "RampCar")
        {
            swiperightsprite.SetActive(true);
            Destroy(swiperightsprite, 2f);
        }

        if (collision.gameObject.tag == "DestroyCar")
        {

            swiperightsprite.SetActive(true);
            Destroy(swiperightsprite, 2f);

        }
    }
}
