using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCounter : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    public static float HitInstance;

    void Start()
    {
        HitInstance = 0f;
    }

    void Update()
    {
        progressText.text = "Hits = " + HitInstance;
    }
}
