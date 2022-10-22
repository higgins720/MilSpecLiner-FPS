using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI HitText;
    public TextMeshProUGUI TimeText;

    public static float HitInstance;

    // For counting down minimum completion time
    public static int StopWatch;
    // For recording actual completion time
    public static bool TimerRunning;

    private float recordedTime;

    void Start()
    {
        recordedTime = 0.0f;
        HitInstance = 0f;
        TimerRunning = false;
    }

    private void Update()
    {
        //Time.timeScale = 1.0f;
        // Time
        if (TimerRunning) {
            recordedTime += ((Time.deltaTime * 100)/100);
        }

        TimeText.text = recordedTime.ToString();
        
        HitText.text = "Hits = " + HitInstance;
    }
}
