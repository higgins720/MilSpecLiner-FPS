using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeScript : MonoBehaviour
{

    private float time;

    [SerializeField]
    private float countDownStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = countDownStart -= Time.deltaTime;
        Debug.Log("Time = " + time);

        if (time <= 0.0f)
        {
            time = 0.0f;
            Debug.Log("Time = " + time);
            enabled = false;
        }
    }
}
