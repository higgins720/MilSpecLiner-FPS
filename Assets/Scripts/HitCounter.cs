using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI HitText;
    public TextMeshProUGUI TimeText;

    public static float HitInstance;
    public static bool TimerRunning;

    public float recordedTime = 0;

    void Start()
    {
        HitInstance = 0f;
        TimerRunning = false;
    }

    private void Update()
    {

        Time.timeScale = 1.0f;

        if (TimerRunning) {
            recordedTime += Time.deltaTime;
        }

        TimeText.text = Mathf.RoundToInt(recordedTime).ToString();
        
        HitText.text = "Hits = " + HitInstance;
    }
}
