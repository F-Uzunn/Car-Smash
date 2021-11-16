using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipeleft : MonoBehaviour
{
    public GameObject[] arabalar;
    public GameObject swipeleftsprite;


    // Update is called once per frame

    private void Start()
    {
        swipeleftsprite.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "RampCar")
        {
            swipeleftsprite.SetActive(true);
            Destroy(swipeleftsprite, 2f);
        }

        if (collision.gameObject.tag == "DestroyCar")
        {

            swipeleftsprite.SetActive(true);
            Destroy(swipeleftsprite, 2f);

        }
    }
}
