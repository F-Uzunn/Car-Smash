using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class SpeedMultiplier : MonoBehaviour
{
    public float SpeedMultip = 0.1f;
    bool furk = true;
    public static SpeedMultiplier Instance;
    // Start is called before the first frame update
    public TextMeshProUGUI TextForLevelIncrement;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TextForLevelIncrement.text = "Level " + PlayerPrefs.GetInt("NumberOfTimesBought");
    }

    // Update is called once per frame
    public void SpeedPurchase()
    {
            if (PlayerPrefs.GetInt("coin") >= 1)
            {
                PlayerPrefs.SetInt("NumberOfTimesBought", (PlayerPrefs.GetInt("NumberOfTimesBought") + 1));
                TextForLevelIncrement.text = "Level " + PlayerPrefs.GetInt("NumberOfTimesBought");
                PlayerPrefs.SetFloat("UPGSpeed", PlayerPrefs.GetFloat("UPGSpeed") + 0.1f);
                MobileInput.Instance.speed = 0.1f + PlayerPrefs.GetFloat("UPGSpeed") + MobileInput.Instance.DefaultSpeed;
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
