using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tankmodepower : MonoBehaviour
{
    public GameObject tankmodeimage;
    public Button button;
    public bool magnett;
    public bool furka;
    public TextMeshProUGUI TextForLevelIncrementtankmode;

    public void Tankmode()
    {

        if (PlayerPrefs.GetInt("Tankmode") >= 1)
        {
            StartCoroutine(tank());

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
        IEnumerator tank()
        {
            button.interactable = false;
            PlayerPrefs.SetInt("Tankmode", (PlayerPrefs.GetInt("Tankmode") - 1));
            TextForLevelIncrementtankmode.text = PlayerPrefs.GetInt("Tankmode") + "x";
            magnett = false;
            GameController.Instance.tankmode = true;
            tankmodeimage.SetActive(true);
            yield return new WaitForSeconds(15);
            GameController.Instance.tankmode = false;
            tankmodeimage.SetActive(false);
            magnett = true;
            button.interactable = true;
        }
    }
}