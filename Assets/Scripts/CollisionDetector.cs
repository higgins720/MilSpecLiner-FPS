using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("TimerStart"))
        {
            Debug.Log("Timer Start");
            HitCounter.TimerRunning = true;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("TimerStop"))
        {
            Debug.Log("Timer Stop");
            HitCounter.TimerRunning = false;
            Destroy(collision.gameObject);
        }
    }
}
