using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class timeslowpowerup : MonoBehaviour
{
    bool furk = true;
    public TextMeshProUGUI TextForLevelIncrementtimeslow;

    void Start()
    {
        TextForLevelIncrementtimeslow.text = PlayerPrefs.GetInt("Timeslow") + "x";
    }

    public void Timeslow()
    {
        if (PlayerPrefs.GetInt("coin") >= 1)
        {
            TextForLevelIncrementtimeslow.text = PlayerPrefs.GetInt("Timeslow") + "x";
            PlayerPrefs.SetInt("Timeslow", (PlayerPrefs.GetInt("Timeslow") + 1));
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 1);
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
}
