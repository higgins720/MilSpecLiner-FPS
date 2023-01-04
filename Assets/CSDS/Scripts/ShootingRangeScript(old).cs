using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime;
using System.Globalization;
using System;


//using UnityEngine.InputSystem;
// Shane was here.

public class ShootingRange : MonoBehaviour
{

    #region CHILD SCRIPTS

    [Title(label: "Child Scripts")]

    [SerializeField]
    TimerScript timerScript;

    [SerializeField]
    ScoreScreenScript scoreScreenScript;

    #endregion
    #region HIT TRACKER

    [SerializeField]
    private TextMeshProUGUI hitText;

    [SerializeField]
    private TextMeshProUGUI hitMarker;

    [SerializeField]
    private int targetHitGoal;

    // Amount of targets eliminated
    public static int iHitsRecorded;

    #endregion
    #region SCORE SCREEN

    [HideInInspector]
    public int iShotsFired;

    public static string sTargetScore;
    public static string sAccuracyScore;
    public static string sLetterGrade;

    #endregion

    private float targetScore;
    private float shotAccuracy;
    private float finalScore;

 
    private long gameStartMS = 0;
    private long currentTimeMS = 0;

 
    private bool gameStartedFlag = false;
    private bool gameOverFlag = false;

    private long lastCountDownSeconds = 0;

 
    private const short GAME_START_MAX_SECONDS = 3;  // How many secconds after lead in time before game offically starts.
    private const short GAME_OVER_MAX_SECONDS = 5;   // How many seconds until the game is over.

    class ShootingRangeTimer : Timer
    {
        public float startTime = 30.0f;
        public float endTime = 0.0f;
    }
    class ThreeSecondDelay : Timer
    {
        public float startTime = 3.0f;
        public float endTime = 0.0f;
    }

    void Start()
    {



        /*    Timer timer = new ShootingRangeTimer();
            Timer delayStart = new ThreeSecondDelay();

            delayStart.timerRunning = true;
            timer.timerRunning = false;
            */

        iHitsRecorded = 0;
        iShotsFired = 0;
        targetScore = 0;
        shotAccuracy = 0;
        finalScore = 0;
    }

    void Update()
    {

        // So we want two different timing sequences.
        // First one is a 3 second count-down to 3 . 2 . 1 GO  To Start, Like a Game Lead In.
        // Second one is a 30 second game time to see how many targets you can clear.   
 
            if (0 == gameStartMS)
            {
                gameStartMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
            else
            {
                currentTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                long deltaMS = currentTimeMS - gameStartMS;

                if ((!gameStartedFlag) && (((GAME_START_MAX_SECONDS * 1000) - deltaMS) <= 0))
                {
                    // If 3 seconds have elapsed then its time for the game to begin. 
                    gameStartedFlag = true;

                    Debug.Log(">>>>>>>> Game Started, 3 seconds elapsed");
                }
                else if (!gameStartedFlag)
                {

                    long wholeNumberSeconds = (long)(deltaMS/1000);



                    //if (deltaMS >= 1000){}
                    // Show countdown
                    //long countDownSeconds = deltaMS % 1000;
                  
                 //   Debug.Log("Count Down Seconds: "+wholeNumberSeconds);
                    //long countDownSeconds = (long)Math.Round(deltaMS / 1000.0);
                    wholeNumberSeconds = GAME_START_MAX_SECONDS - wholeNumberSeconds;
                    if (wholeNumberSeconds != lastCountDownSeconds)
                    {
                        // Screen update to show 
                        Debug.Log(" *********"+  wholeNumberSeconds + "");
                    }
                    lastCountDownSeconds = wholeNumberSeconds;
                }

                if ((gameStartedFlag) && (!gameOverFlag))
                {

                    long gameOverElapsed = GAME_START_MAX_SECONDS * 1000 + GAME_OVER_MAX_SECONDS * 1000;

                    if ((gameOverElapsed - deltaMS) <= 0)
                    {
                        gameOverFlag = true;
                        Debug.Log(">>>>>>>>>> Game Over -- " + gameOverElapsed / 1000 + " Seconds have elapsed");
                    }
                }

                if ((gameOverFlag) && (!enabled))
                {
                    CalculateScores();
                    StartCoroutine(showScoreScreen());
                    enabled = false;
                }
            }
    
        /*
                delayStart.RunTimer();
                if (!delayStart.timerRunning) 
                {
                    timer.timerRunning = true;
                }

                if (timer.timerRunning) 
                {
                    hitText.text = iHitsRecorded.ToString();
                    if (Input.GetButtonDown("Fire1")) 
                    {
                        iShotsFired += 1;
                        Debug.Log("Shots: " + iShotsFired);
                    }
                } 
                else if (!timer.timerRunning) 
                {
                    CalculateScores();
                    StartCoroutine(showScoreScreen());
                    enabled = false;
                }
                */
    }

    IEnumerator showScoreScreen()
    {
        yield return new WaitForSeconds(1);
        scoreScreenScript.Show();
    }

    private void CalculateScores()
    {
        // get shot fired to shots landed percentage
        shotAccuracy = (((float)iHitsRecorded / (float)iShotsFired) * 100.0f);
        sAccuracyScore = shotAccuracy.ToString("0.00") + "%";

        Debug.Log("Hits/Shots: " + iHitsRecorded + "/" + iShotsFired);
        Debug.Log("Accuracy: " + shotAccuracy);

        // get hit number to hit goal percentage
        targetScore = (((float)iHitsRecorded / targetHitGoal) * 100.0f);
        sTargetScore = targetScore.ToString("0.00") + "%";

        Debug.Log("Hits/Goal: " + iHitsRecorded + "/" + targetHitGoal);
        Debug.Log("Target Score: " + targetScore);

        // get average of target and accuracy score
        finalScore = ((targetScore + shotAccuracy) / 2);

        Debug.Log("Final Score: " + finalScore);

        sLetterGrade = ConvertToGrade(finalScore);

        // if (iShotsFired > 0 && iHitsRecorded > 0 && targetHitGoal > 0) {
        //     return;
        // } else {
        //     Debug.Log("You can't divide by zero. Try shooting something next time.");
        // }

        //timeBonus = ((endTime / originalTime) * 100);
        //TimeScoreText.text = timeBonus.ToString("0.00");

        // Take average of target and accuracy score, and factor in the time multiplier 
        //targetScore = ((ssHitNumber / targetHitGoal) * 100.0f);
    }

    private string ConvertToGrade(float finalScore)
    {

        if (finalScore >= 130.0f)
        {
            return "S++";
        }
        else if (finalScore >= 120.0f && finalScore < 130.0f)
        {
            return "S+";
        }
        else if (finalScore >= 110.0f && finalScore < 120.0f)
        {
            return "S";
        }
        else if (finalScore >= 100.0f && finalScore < 110.0f)
        {
            return "A+";
        }
        else if (finalScore >= 90.0f && finalScore < 100.0f)
        {
            return "A";
        }
        else if (finalScore >= 80.0f && finalScore < 90.0f)
        {
            return "B";
        }
        else if (finalScore >= 70.0f && finalScore < 80.0f)
        {
            return "C";
        }
        else
        {
            return "D";
        }

    }
}
