using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerTrigger : MonoBehaviour
{
    public bool triggered;

    void start() {
        triggered = false;
    }
    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Player")) {
            triggered = true;
        }
    }
}
