using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinmagnetscript : MonoBehaviour
{
    public GameObject coinmagnetimage;
    public GameObject coinmagnet;
    public bool magnet;
    public bool furk;


    public void PowerupPurchase()
    {
        if (PlayerPrefs.GetInt("NumberofTimesPower") >= 1)
        {
            if (magnet)
            {
                StartCoroutine(Wait());
            }
        }

        else
        {
            if (furk)
            {
                Debug.Log("You Dont Have Enough Coins");
                furk = false;
            }
            else
            {
                furk = true;
            }

        }
    }

        IEnumerator Wait()
        {
            magnet = false;
            GameController.Instance.coinmagnet = true;
            coinmagnetimage.SetActive(true);
            yield return new WaitForSeconds(15);
            GameController.Instance.coinmagnet = false;
            coinmagnetimage.SetActive(false);
            magnet = true;
        }

}
