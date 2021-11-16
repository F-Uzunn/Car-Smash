using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public bool check = true;
    public GameObject speedupgradebutton;
    public GameObject magnetbutton;
    public GameObject slowbutton;
    public GameObject tankbutton;
    public void Tap()
    {
        if (check)
        {
            GameController.Instance.Pause = true;
            speedupgradebutton.SetActive(false);
            magnetbutton.SetActive(false);
            slowbutton.SetActive(false);
            tankbutton.SetActive(false);
        }
    }
}
