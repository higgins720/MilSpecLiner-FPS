using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Player")) {
            HitCounter.courseComplete = true;
        }
    }
}
