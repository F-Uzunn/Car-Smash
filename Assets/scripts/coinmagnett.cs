using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class coinmagnett : MonoBehaviour
{
    public GameObject coinmagnetimage;
    public Button button;
    public bool magnet;
    public bool furk;
    public TextMeshProUGUI TextForLevelIncrement;

    public void PowerupPurchase()
    {
        
        if (PlayerPrefs.GetInt("NumberofTimesPower") >= 1)
        {
           StartCoroutine(Power());

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
        IEnumerator Power()
        {
            button.interactable = false;
            PlayerPrefs.SetInt("NumberofTimesPower", (PlayerPrefs.GetInt("NumberofTimesPower") - 1));
            TextForLevelIncrement.text = PlayerPrefs.GetInt("NumberofTimesPower") + "x";
            magnet = false;
            GameController.Instance.coinmagnet = true;
            coinmagnetimage.SetActive(true);
            yield return new WaitForSeconds(15);
            GameController.Instance.coinmagnet = false;
            coinmagnetimage.SetActive(false);
            magnet = true;
            button.interactable = true;
        }
    }
}
