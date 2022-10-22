using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI HitText;
    public TextMeshProUGUI TimeText;
    public static float HitInstance;
    public bool TimerStart;

    void Start()
    {
        HitInstance = 0f;
    }

    void Update()
    {

        while (TimerStart == true) {
            // start timer
            TimeText.text = "Clock is running";
        }

        HitText.text = "Hits = " + HitInstance;
    }
}
