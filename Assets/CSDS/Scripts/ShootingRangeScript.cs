using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.InputSystem;

public class ShootingRangeScript : MonoBehaviour
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

    // class ThreeSecondDelay : TimerScript
    // {
    //     // Redefine variables
    //     public override float countDownStart = 3.0f;
    //     public override bool countUp = false;
    // }

    // TimerScript delayStart = new ThreeSecondDelay();

    void Start() {
        iHitsRecorded = 0;
        iShotsFired = 0;
        targetScore = 0;
        shotAccuracy = 0;
        finalScore = 0;

    }

    void Update() {
        if (!timerScript.TimerIsDone) 
        {
            hitText.text = iHitsRecorded.ToString();
            if (Input.GetButtonDown("Fire1")) 
            {
                iShotsFired += 1;
            }
        } 
        else if (timerScript.TimerIsDone) 
        {
            CalculateScores();
            StartCoroutine(showScoreScreen());
            enabled = false;
        }
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

        // get hit number to hit goal percentage
        targetScore = (((float)iHitsRecorded / targetHitGoal) * 100.0f);
        sTargetScore = targetScore.ToString("0.00") + "%";

        // get average of target and accuracy score
        finalScore = ((targetScore + shotAccuracy) / 2);

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

    private string ConvertToGrade(float finalScore) {

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
        } else {
            return "D";
        }
        
    }
}
