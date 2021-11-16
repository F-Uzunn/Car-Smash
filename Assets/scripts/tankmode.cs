using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class tankmode : MonoBehaviour
{
    bool furk = true;
    public TextMeshProUGUI TextForLevelIncrementtankmode;

    void Start()
    {
        TextForLevelIncrementtankmode.text = PlayerPrefs.GetInt("Tankmode") + "x";
    }

    public void TankMode()
    {
        if (PlayerPrefs.GetInt("coin") >= 1)
        {
            TextForLevelIncrementtankmode.text = PlayerPrefs.GetInt("Tankmode") + "x";
            PlayerPrefs.SetInt("Tankmode", (PlayerPrefs.GetInt("Tankmode") + 1));
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
