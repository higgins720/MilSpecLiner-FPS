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

    [Title(label: "GUI")]

    [SerializeField]
    private TextMeshProUGUI hitText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private GameObject scoreScreenGUI;

    #endregion

    private float endTime;

    // Amount of targets eliminated, recorded from HitTracker script
    public static float hitNumber;

    // For recording actual completion time
    public static bool timerRunning;
    public static bool courseComplete;

    // Should an end screen appear with an option to restart?
    private bool showScoreScreen;

    void Start()
    {
        hitNumber = 0f;
        timerRunning = false;
        courseComplete = false;
        scoreScreenGUI.SetActive(true);
        showScoreScreen = true;
    }

    private void Update()
    {
        if (timerRunning) {
            // Time ticks down
            endTime = timeToComplete -= Time.deltaTime;
            SetTimerText();
            SetHitText();
            // End Timer Trigger sets course complete to true
            if (courseComplete)
            {
                if (courseComplete && showScoreScreen) {
                    StartCoroutine(ScoreScreen());
                    enabled = false;
                }
                //timerRunning = false;
                SetTimerText();
                enabled = false;
            }
            if (endTime <= 0.00f) 
            {
                endTime = 0.00f;
                timeText.color = Color.red;
                courseComplete = true;
                //timerRunning = false;
                SetTimerText();
                StartCoroutine(ScoreScreen());
                enabled = false;
            }
        }
    }

    private void SetTimerText()
    {
        timeText.text = endTime.ToString("0.00");
    }

    private void SetHitText()
    {
        hitText.text = hitNumber + " / " + targetAmount;
    }

    IEnumerator ScoreScreen()
    {
        yield return new WaitForSeconds(1);
        scoreScreenGUI.GetComponent<ScoreScreenController>().Show();
    }

}
