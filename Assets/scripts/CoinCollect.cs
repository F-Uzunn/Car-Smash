using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public GameObject [] arabalar;
    public GameObject coin;
    public GameObject araba;
    float distance;


    void Update()
    {
        if(GameController.Instance.coinmagnet) 
        {
            distance = Vector3.Distance(transform.position, araba.transform.position);
            //Debug.Log("distance" + distance);

            if (distance < 40)
            {
                transform.position = Vector3.MoveTowards(transform.position, araba.transform.position, 70f * Time.deltaTime);
            }
            else { }
        }
        
    }

    void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.tag == "RampCar")
        {
            MobileInput.Instance.pickedCoin++;
            Destroy(coin);
        }

        if (collision.gameObject.tag == "DestroyCar")
        {
            MobileInput.Instance.pickedCoin++;
            Destroy(coin);
        }
    }
}
