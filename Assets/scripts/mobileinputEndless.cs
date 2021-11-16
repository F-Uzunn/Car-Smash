using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class mobileinputEndless : MonoBehaviour
{
    public int pickedCoin = 0;
    public GameObject RampCar;
    public GameObject monster;
    public float speed = 10;
    private const float DEADZONE = 100.0f;
    public GameObject TapToStart;
    public GameObject particles;
    public GameObject monsterSlider;


    public static mobileinputEndless Instance { set; get; }

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool StartTap = false;
    public bool shake = false;
    public float currentScore = 0;
    public float limit = 0;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentScore = 0;
        limit = 2000;
        particles.SetActive(false);
    }

    public void Update()
    {
        //TANK MODE ACTIVE
        if (GameController.Instance.tankmode)
        {
            RampCar.transform.gameObject.tag = "hehe";
            monster.transform.gameObject.tag = "hehe";
        }
        else 
        {
            RampCar.transform.gameObject.tag = "RampCar";
            monster.transform.gameObject.tag = "DestroyCar";
        }

        //Limit arttıkça speed artıyor.
        if (GameController.Instance.Pause)
        {
            if (!GameController.Instance.PauseGame)
            currentScore++;
            
            if (currentScore>limit)
            {
                limit = limit+2000;
                speed = speed+1f;
            }
        }


        //PAUSE GAME
        if (!GameController.Instance.Pause || GameController.Instance.PauseGame)
        {
            Time.timeScale = 0f;
        }
        else
        {
            TapToStart.SetActive(false);
            if (GameController.Instance.timeslow)
            {
                Time.timeScale = 0.6f;
            }
            else { Time.timeScale = 1f; }
        }



        //FAIL GAME
        if (GameController.Instance.isGameFinished)
        {
            speed = 0;
            particles.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetFloat("fuki", speed);
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }



        
        //FINISH GAME
        if (GameController.Instance.isGameEnded)
        {
            speed = 0;
            particles.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetFloat("fuki", speed);
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }


        if (Input.GetKey("z"))
        {
            PlayerPrefs.SetInt("coin", 0);
            PlayerPrefs.SetInt("coin1", 0);
        }

        if (Input.GetKey("x"))
        {
            speed = 10;
            PlayerPrefs.SetFloat("UPGSpeed", 0);
        }
        if (Input.GetKey("c"))
        {
            PlayerPrefs.SetInt("NumberOfTimesBought", 1);
            PlayerPrefs.SetInt("Level", 2);
        }

        if (Input.GetKey("q"))
        {
            PlayerPrefs.SetInt("NumberofTimesPower", 1);
            PlayerPrefs.SetInt("Timeslow", 1);
            PlayerPrefs.SetInt("Tankmode", 1);
        }



        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;


        //Checking for input standalone
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        //releasing mouse button up so we reset vector2.zero
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            startTouch = swipeDelta = Vector2.zero;
        }

        //Checking for input on mobile
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            // if its cancelled or ended again we reset to Vector2.zero
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                isDraging = false;
                startTouch = swipeDelta = Vector2.zero;
        }



        //Calculating distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }



        if (swipeDelta.magnitude > DEADZONE)
        {
            //this is a confirmed swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                    swipeLeft = true;

                if (swipeLeft == true)
                {
                    RampCar.SetActive(false);
                    monster.SetActive(true);
                    monsterSlider.SetActive(true);
                }


                else
                    swipeRight = true;

                if (swipeRight == true)
                {

                    RampCar.SetActive(true);
                    monster.SetActive(false);
                    monsterSlider.SetActive(false);
                }


            }
            startTouch = swipeDelta = Vector2.zero;
        }


    }
}
