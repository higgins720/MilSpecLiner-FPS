using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region PARENT SCRIPT

    //[SerializeField]
    //ShootingRangeScript shootingRangeScript;

    #endregion
    #region MODIFYABLE

    protected float startTime;
    protected float endTime;

    #endregion
    
    private float time;
    private bool timerRunning;
    protected bool countUp;

    void Start() 
    {
        time = 0.0f;
        timerRunning = false;

        if (startTime < endTime) 
        {
            countUp = false;
        } 
        else if (startTime > endTime)
        {
            countUp = true;
        } 
        else 
        {
            Debug.Log("Start and end time must be different.");
        }
    }
    protected void RunTimer() 
    {
        if (timerRunning) 
        {
            time = (countUp) ? startTime += Time.deltaTime : startTime -= Time.deltaTime;

            if (countUp && time >= endTime) 
            {
                time = endTime;
                timerRunning = false;
                enabled = false;
            }
            if (!countUp && time <= 0.0f) 
            {
                time = 0.0f;
                timerRunning = false;
                enabled = false;
            }

        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (timerStart)
    //     {
    //         RunTimer();
    //     }

    //     if (!countUp && timerStart) 
    //     {
    //         time = countDownStart -= Time.deltaTime;
    //         if (time <= 0.0f) 
    //         {
    //             time = 0.0f;
    //             TimerIsDone = true;
    //             enabled = false;
    //         }
    //     } else if (countUp && timerStart) 
    //     {
    //         time += Time.deltaTime;
    //         if (time >= countUpEnd) 
    //         {
    //             time = countUpEnd;
    //             TimerIsDone = true;
    //             enabled = false;
    //         }
    //     }
    // }
}