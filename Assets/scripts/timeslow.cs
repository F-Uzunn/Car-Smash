using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timeslow : MonoBehaviour
{
    public GameObject timeslowimage;
    public Button button;
    public bool magnett;
    public bool furka;
    public TextMeshProUGUI TextForLevelIncrementtimeslow;
    public void Timeslowww()
    {

        if (PlayerPrefs.GetInt("Timeslow") >= 1)
        {
            StartCoroutine(time());

        }

        else
        {
            if (furka)
            {
                Debug.Log("You Dont Have Enough Coins");
                furka = false;
            }
            else
            {
                furka = true;
            }

        }
        IEnumerator time()
        {
            button.interactable = false;
            PlayerPrefs.SetInt("Timeslow", (PlayerPrefs.GetInt("Timeslow") - 1));
            TextForLevelIncrementtimeslow.text = PlayerPrefs.GetInt("Timeslow") + "x";
            magnett = false;
            GameController.Instance.timeslow = true;
            timeslowimage.SetActive(true);
            yield return new WaitForSeconds(10);
            GameController.Instance.timeslow = false;
            timeslowimage.SetActive(false);
            magnett = true;
            button.interactable = true;
        }
    }
}
