using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    #region PARENT SCRIPT

    [SerializeField]
    ShootingRangeScript shootingRangeScript;

    #endregion

    #region FIELDS SERIALIZED

    [SerializeField]
    private TextMeshProUGUI timerText;

    [Title(label: "Count Down")]

    [SerializeField]
    private float countDownStart;

    [Title(label: "Count Up")]

    [SerializeField]
    private bool countUp;

    [SerializeField]
    private float countUpEnd;

    [Title(label: "Triggers")]

    [SerializeField] 
    private bool startOnTrigger;

    [SerializeField] 
    private GameObject startTrigger;

    [SerializeField]
    private bool endOnTrigger;

    [SerializeField] 
    private GameObject endTrigger;

    #endregion

    [HideInInspector]
    public bool TimerIsDone;

    [HideInInspector]
    public bool timerStart;

    //[HideInInspector]
    //public bool TimerIsRunning;

    private float time;

    // TODO: Code conditional start/end with triggers.
    void Start() 
    {
        time = 0.0f;
        if (!startOnTrigger) {
            timerStart = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (startOnTrigger && startTrigger.GetComponent<StartTimerTrigger>().triggered) {
            timerStart = true;
        }

        if (timerStart)
        {
            // Count down timer
            if (!countUp)
            {
                time = countDownStart -= Time.deltaTime;
                showTime();
                if (endOnTrigger && endTrigger.GetComponent<EndTimerTrigger>().triggered) {
                    stopTimer(time);
                    enabled = false;
                }
                if (time <= 0.0f)
                {
                    stopTimer(0.0f);
                    //showTime();
                    enabled = false;
                }
            }
            // Count up timer
            else if (countUp)
            {
                time += Time.deltaTime;
                showTime();
                
                if (endOnTrigger && endTrigger.GetComponent<EndTimerTrigger>().triggered) {
                    stopTimer(time);
                    enabled = false;
                }
                if (time >= countUpEnd)
                {
                    stopTimer(countUpEnd);
                    //showTime();
                    enabled = false;
                }
            }
        }
        
    }

    private void stopTimer(float t) {
        time = t;
        TimerIsDone = true;
    }

    private void showTime() 
    {
        timerText.text = time.ToString("0.00");
    }
}
