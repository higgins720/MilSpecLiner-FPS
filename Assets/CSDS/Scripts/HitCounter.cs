using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    #region FIELDS SERIALIZED

    [Title(label: "Scoring")]

    [SerializeField]
    private float timeToComplete;
    [SerializeField]
    private float targetAmount;

    // Time left at the end of the run
    private float endTime;

    // Should an end screen appear with an option to restart?
    //private bool showScoreScreen;

    [Title(label: "HUD GUI")]

    [SerializeField]
    private TextMeshProUGUI hitText;

    [SerializeField]
    private TextMeshProUGUI timeText;


    [Title(label: "Score Screen GUI")]

    [SerializeField]
    private GameObject scoreScreenGUI;
    
    [SerializeField]
    private TextMeshProUGUI TargetScoreText;

    [SerializeField]
    private TextMeshProUGUI TimeScoreText;

    [SerializeField]
    private TextMeshProUGUI AccuracyScoreText;

    [SerializeField]
    private TextMeshProUGUI GradeText;

    #endregion

    #region PUBLIC VARIABLES

    // Record the amount of shots that are fired
    public static float ssShotsFired;

    // Amount of targets eliminated
    public static float ssHitNumber;

    // For recording actual completion time
    public static bool timerRunning;
    public static bool courseComplete;

    #endregion

    #region SCORE CALCULATION

    // To preserve number for calculating the time score at the end
    private float originalTime;

    private float targetScore;
    private float accuracyScore;
    private float timeBonus;
    private float finalScore;

    private string gradeScore;

    #endregion
    
    void Start()
    {
        ssHitNumber = 0f;
        ssShotsFired = 0f;
        timerRunning = false;
        courseComplete = false;
        scoreScreenGUI.SetActive(true);
        originalTime = timeToComplete;
    }

    private void Update()
    {
        if (!timerRunning) {
            ssShotsFired = 0f;
            ssHitNumber = 0f;
        } else {

            SetTimerText();
            hitText.text = ssHitNumber + " / " + targetAmount;

            // Time ticks down
            endTime = timeToComplete -= Time.deltaTime;

            if (endTime == 0.00f) 
            {
                endTime = 0.00f;
                timeText.color = Color.red;
                SetTimerText();
                enabled = false;

                //courseComplete = true;
                //timerRunning = false;
                //StartCoroutine(ScoreScreen());
            }

            // End Timer Trigger sets course complete to true
            if (courseComplete)
            {
                StartCoroutine(ScoreScreen());
                SetTimerText();
                //timerRunning = false;
                enabled = false;
            }

        } 
    }

    private void SetTimerText() {
        timeText.text = endTime.ToString("0.00");
    }

    private void ConvertToGrade(float grade) {

        if (grade >= 130.0f) 
        {
            gradeScore = "S++";
        } 
        else if (grade >= 120.0f && grade < 130.0f) 
        {
            gradeScore = "S+";
        } 
        else if (grade >= 110.0f && grade < 120.0f)
        {
            gradeScore = "S";
        }
        else if (grade >= 100.0f && grade < 110.0f)
        {
            gradeScore = "A+";
        }
        else if (grade >= 90.0f && grade < 100.0f)
        {
            gradeScore = "A";
        }
        else if (grade >= 80.0f && grade < 90.0f)
        {
            gradeScore = "B";
        }
        else if (grade >= 70.0f && grade < 80.0f)
        {
            gradeScore = "C";
        } else {
            gradeScore = "D";
        }
        
    }

    private void CalculateScores() 
    {
        targetScore = ((ssHitNumber / targetAmount) * 100);
        TargetScoreText.text = ssHitNumber.ToString() + "/" + targetAmount.ToString();

        accuracyScore = ((ssHitNumber / ssShotsFired) * 100);
        AccuracyScoreText.text = accuracyScore.ToString("0.0") + "%";

        timeBonus = ((endTime / originalTime) * 100);
        Debug.Log("Time Bonus = " + timeBonus);
        TimeScoreText.text = timeBonus.ToString("0.00");

        // Take average of target and accuracy score, and factor in the time multiplier 
        finalScore = ((targetScore + accuracyScore) / 2) + timeBonus;
        Debug.Log("Final Score = " + finalScore);

        ConvertToGrade(finalScore);

        GradeText.text = gradeScore;
    }

    IEnumerator ScoreScreen()
    {
        CalculateScores();
        yield return new WaitForSeconds(1);
        scoreScreenGUI.GetComponent<ScoreScreenController>().Show();
    }

}
