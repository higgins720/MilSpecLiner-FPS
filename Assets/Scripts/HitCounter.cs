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

    public TextMeshProUGUI hitText;
    public TextMeshProUGUI timeText;

    public float timeToComplete;
    public float numberOfTargets;

    private float endTime;

    // Should an end screen appear with an option to restart?
    public float endScreen;

    void Start()
    {
        hitNumber = 0f;
        timerRunning = false;
    }

    private void Update()
    {
        if (timerRunning) {
            endTime = timeToComplete -= Time.deltaTime;
            SetTimerText();
            SetHitText();
            if (endTime <= 0.00f) {
                endTime = 0.00f;
                SetTimerText();
                timeText.color = Color.red;
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
        hitText.text = "Hits = " + hitNumber + " / " + numberOfTargets;
    }

}
