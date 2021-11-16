using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isGameFinished = false;
    public bool isGameEnded = false;
    public bool Pause = false;
    public bool PauseGame = false;
    public bool coinmagnet = false;
    public bool timeslow = false;
    public bool tankmode = false;
    public static GameController Instance;
    public void OnApplicationPause()
    {
        PlayerPrefs.SetString("isGameClosed","closed");
    }
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

    }
}
