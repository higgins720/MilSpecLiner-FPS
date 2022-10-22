using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerTrigger : MonoBehaviour
{

    public float NumberOfTargets;
    public float SecondsToComplete;

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Player")) {
            HitCounter.TimerRunning = true;
        }
    }
}
