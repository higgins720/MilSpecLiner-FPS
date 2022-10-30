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

    #endregion

    [HideInInspector]
    public bool TimerIsDone;

    private bool timerStart;

    [HideInInspector]
    public bool TimerIsRunning;

    private float time;

    void Start() 
    {
        time = 0.0f;
        timerStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            if (!countUp)
            {
                time = countDownStart -= Time.deltaTime;
                showTime();
                if (time <= 0.0f)
                {
                    time = 0.0f;
                    showTime();
                    TimerIsDone = true;
                    enabled = false;
                }
            }
            else if (countUp)
            {
                time += Time.deltaTime;
                showTime();
                if (time >= countUpEnd)
                {
                    time = countUpEnd;
                    showTime();
                    TimerIsDone = true;
                    enabled = false;
                }
            }
        }
    }

    private void showTime() 
    {
        timerText.text = time.ToString("0.00");
    }
}
