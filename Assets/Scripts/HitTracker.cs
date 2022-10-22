using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack.Legacy;

public class HitTracker : MonoBehaviour
{
    //public TargetScript TargetScript;
    //public GameObject target;

    public bool isHit;

    private void hitRecord()
    {
        if (isHit == true) {
            Debug.Log("HIT");
        }
    }
    
}