using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Player")) {
            HitCounter.timerRunning = true;
        }
    }
}
