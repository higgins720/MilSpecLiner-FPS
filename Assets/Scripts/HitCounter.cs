using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    // Amount of targets eliminated
    public static float hitNumber;

    // For recording actual completion time
    public static bool timerRunning;
    public static bool courseComplete;

    public TextMeshProUGUI hitText;
    public TextMeshProUGUI timeText;
    public GameObject scoreScreenGUI;

    public float timeToComplete;
    public float numberOfTargets;

    private float endTime;

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
                SetTimerText();
                timeText.color = Color.red;
                //timerRunning = false;
                enabled = false;
            }
        }
    }

    private void SetTimerText()
    {
        timeText.text = endTime.ToString("0.00");
    }

    IEnumerator ScoreScreen()
    {
        yield return new WaitForSeconds(1);
        scoreScreenGUI.GetComponent<ScoreScreenController>().Show();
    }

    private void SetHitText()
    {
        hitText.text = hitNumber + " / " + numberOfTargets;
    }

}
