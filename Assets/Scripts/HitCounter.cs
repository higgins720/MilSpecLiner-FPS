using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    private float hitNumber;
    public static float HitInstance = 1f;

    //private void addHit() {
        //if (TargetScript.isHit = true) {
            //hitNumber += 1f;
        //}
    //}

    // Start is called before the first frame update
    void Start()
    {
        hitNumber = 0;
    }

    void Update()
    {
        progressText.text = "Hits = " + HitInstance;
    }
}
