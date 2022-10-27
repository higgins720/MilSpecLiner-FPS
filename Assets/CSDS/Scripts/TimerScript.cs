using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI timerText;

    [Title(label: "Count Down")]

    [SerializeField]
    private float countDownStart;

    [SerializeField]
    private float timeWarning;

    [Title(label: "Count Up")]

    [SerializeField]
    private bool countUp;

    [SerializeField]
    private float countUpEnd;
    
    private float time;

    public static bool TimerIsDone;

    void Start() 
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!countUp) {
            time = countDownStart -= Time.deltaTime;
            showTime();
            if (time <= 0.0f) {
                time = 0.0f;
                showTime();
                TimerIsDone = true;
                enabled = false;
            }
        } else if (countUp) {
            time += Time.deltaTime;
            showTime();
            if (time >= countUpEnd) {
                time = countUpEnd;
                showTime();
                TimerIsDone = true;
                enabled = false;
            }
        }
    }

    private void showTime() {
        timerText.text = time.ToString("0.00");
    }
}
