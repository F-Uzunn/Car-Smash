using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class powerup : MonoBehaviour
{
    bool furk = true;
    public static powerup Instance;
    // Start is called before the first frame update
    public TextMeshProUGUI TextForLevelIncrementmagnet;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TextForLevelIncrementmagnet.text = PlayerPrefs.GetInt("NumberofTimesPower")+"x";
        
    }

    //Coin magnet powerup

    public void SpeedPurchase()
    {
            if (PlayerPrefs.GetInt("coin") >= 1)
            {
                TextForLevelIncrementmagnet.text = PlayerPrefs.GetInt("NumberofTimesPower") + "x";
                PlayerPrefs.SetInt("NumberofTimesPower", (PlayerPrefs.GetInt("NumberofTimesPower") + 1));
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
