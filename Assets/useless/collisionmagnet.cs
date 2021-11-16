using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionmagnet : MonoBehaviour

{
    public GameObject coinmagnetimage;
    public GameObject coinmagnet;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DestroyCar")
        {
            coinmagnet.GetComponent<Renderer>().enabled = false;
            StartCoroutine(Wait());
        }

        if (collision.gameObject.tag == "RampCar")
        {
            coinmagnet.GetComponent<Renderer>().enabled = false;
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            GameController.Instance.coinmagnet = true;
            coinmagnetimage.SetActive(true);
            yield return new WaitForSeconds(15);
            GameController.Instance.coinmagnet = false;
            coinmagnetimage.SetActive(false);
        }

    }
}
