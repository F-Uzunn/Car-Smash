using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class GameUI : MonoBehaviour
{
    public Transform ARABALAR;
    public Transform EndLine;
    public Slider slider;
    public TextMeshProUGUI pickedCoin;
    public TextMeshProUGUI pickedCoin1;
    public Text UpperCoin;
    public GameObject GameOverObject;
    public GameObject LevelCompleted;
    public GameObject swipeleftsprite;
    public bool check = true;
    public Text scoreAmount;
    public float currScore = 0;


    bool Checker = true;
    float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        currScore = 0;
        if (PlayerPrefs.GetString("isGameClosed") == "closed")
        {
            loadlevel();
        }

        if (PlayerPrefs.GetInt("coin") != PlayerPrefs.GetInt("coin1") && PlayerPrefs.GetInt("coin1")!=0)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin1"));
            UpperCoin.text = PlayerPrefs.GetInt("coin").ToString();
        }
        //
        maxDistance = getDistance();
        GameOverObject.SetActive(false);
        Checker = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.Pause) 
        {
            if(!GameController.Instance.PauseGame)
            scoreAmount.text = currScore.ToString("0");
                if (!GameController.Instance.isGameFinished)
                {
                    currScore++;
                }
                
        }

        //GAME OVER UI EKRANI
        UpperCoin.text = PlayerPrefs.GetInt("coin").ToString();
        if (GameController.Instance.isGameFinished)
        {
            if (Checker)
            {
                
                pickedCoin.text = "+" + MobileInput.Instance.pickedCoin.ToString();
                GameOverObject.SetActive(true);
                StartCoroutine(CoinAddCount());
                Checker = false;

            }

        }

        //LEVEL COMPLETE UI EKRANI
        UpperCoin.text = PlayerPrefs.GetInt("coin").ToString();
        if (GameController.Instance.isGameEnded)
        {
            if (Checker)
            {
                pickedCoin1.text = "+" + MobileInput.Instance.pickedCoin.ToString();
                LevelCompleted.SetActive(true);
                StartCoroutine(CoinAddCount());
                Checker = false;
            }
        }

        //Progress Bar
        if (ARABALAR.position.z <= maxDistance && ARABALAR.position.x <= EndLine.position.x)
        {
            float distance = 1 - (getDistance() / maxDistance);
            setProgress(distance);
        }
    }

    public IEnumerator CoinAddCount()
    {
        if (MobileInput.Instance.pickedCoin!=0)
        {
            PlayerPrefs.SetInt("coin1", (PlayerPrefs.GetInt("coin") + MobileInput.Instance.pickedCoin));

            for (int i = 0; i < MobileInput.Instance.pickedCoin; i++)
            {
                PlayerPrefs.SetInt("coin", (PlayerPrefs.GetInt("coin") + 1));
                UpperCoin.text = PlayerPrefs.GetInt("coin").ToString();
                yield return new WaitForSeconds(2f/MobileInput.Instance.pickedCoin);
            }
        }
    }
    public void loadlevel()
    {
        PlayerPrefs.SetString("isGameClosed", "notClosed");
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        
        if (SceneManager.sceneCountInBuildSettings>PlayerPrefs.GetInt("Level") + 1)
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }

    float getDistance()
    {
        return Vector3.Distance(ARABALAR.position, EndLine.position);
    }

    void setProgress(float p)
    {
        slider.value = p;
    }
}