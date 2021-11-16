using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class collisionWall : MonoBehaviour
{

    public GameObject cube;
    public GameObject particle;
    private IEnumerator coroutine;

    void OnCollisionEnter(Collision collision)
    {
        
        //checking if tankmode is active or no
        if (GameController.Instance.tankmode)
        {
            Destroy(cube);
            CameraShaker.Instance.ShakeOnce(0.8f, 3.5f, 0.1f, 1f);
        }
        else
        {
            if (collision.gameObject.tag == "RampCar")
            {
                GameController.Instance.isGameFinished = true;
                CameraShaker.Instance.ShakeOnce(3f, 3f, 0.1f, 0.5f);


            }
        }


        if (collision.gameObject.tag == "DestroyCar")
        {
            CameraShaker.Instance.ShakeOnce(0.8f, 3.5f, 0.1f, 1f);
            explode();
            Destroy(cube);
        }

        
    }

    void explode()
    {
        particle.SetActive(true);
        Destroy(particle, 1.5f);
    }
}
