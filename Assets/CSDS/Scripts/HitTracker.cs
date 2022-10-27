using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitTracker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hitText;

    [SerializeField]
    private TextMeshProUGUI hitMarker;
    
    // Amount of targets eliminated
    public static int HitsRecorded;

    private void Update() {
        setHitText();
    }

    private void setHitText() {
        hitText.text = HitsRecorded.ToString();
    }

}