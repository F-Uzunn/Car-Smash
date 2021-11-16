using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class coinpowerup : MonoBehaviour
{
    public float SpeedMultip = 0.1f;
    bool furk = true;
    public static coinpowerup Instance;
    // Start is called before the first frame update
    public TextMeshProUGUI TextForLevelIncrement;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TextForLevelIncrement.text = "x" + PlayerPrefs.GetInt("powerupCount");
    }

    // Update is called once per frame
    public void powerup()
    {
        if (PlayerPrefs.GetInt("coin") >= 100)
        {
            PlayerPrefs.SetInt("powerupCount", (PlayerPrefs.GetInt("powerupCount") + 1));
            TextForLevelIncrement.text = "x" + PlayerPrefs.GetInt("powerupCount");
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 100);
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
