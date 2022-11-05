using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    private static HitManager _instance;
    public static HitManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Hit Manager is null");

            return _instance;
        }
    }

    public bool criticalHit;
    public bool regularHit;

    public void targetHit(string type) {
        ShootingRangeScript.iHitsRecorded += 1;
        switch (type)
        {
            case "critical":
                criticalHit = true;
                break;
            default:
                regularHit = true;
                break;
        }
    }

    private void Awake()
    {
        _instance = this;
        criticalHit = regularHit = false;
    }
    
}
