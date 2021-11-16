using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class collisioncars : MonoBehaviour
{ 
    public GameObject sparkleParticles;

    void OnCollisionEnter(Collision collision)
    {
        //Checking if tankmode is active or no
        if (GameController.Instance.tankmode)
        {
            CameraShaker.Instance.ShakeOnce(0.5f, 2f, 0.1f, 0.5f);
        }
        else
        {
            if (collision.gameObject.tag == "DestroyCar")
            {
                GameController.Instance.isGameFinished = true;
                CameraShaker.Instance.ShakeOnce(3f, 3f, 0.1f, 0.5f);
            }
        }
    
            if(collision.gameObject.tag == "RampCar")
            {
                Destroy(gameObject, 1f);
                CameraShaker.Instance.ShakeOnce(0.5f, 2f, 0.1f, 0.5f);
                explode();
            }
    }

    void explode()
    {
        sparkleParticles.SetActive(true);

        Destroy(sparkleParticles, 1.5f);


    }
}
