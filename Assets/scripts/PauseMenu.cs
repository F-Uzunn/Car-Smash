using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool check = true;
    public void PauseGame()
    {
        if (check)
        {
            GameController.Instance.PauseGame = true;
            check = false;
        }
        else
        {
            GameController.Instance.PauseGame = false;
            check = true;
        }
    }

}