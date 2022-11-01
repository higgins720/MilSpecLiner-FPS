using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;

    [SerializeField]
    private int bonusPoints;

    //Used to check if the target has been hit

    [HideInInspector]
	public bool isHit = false;

    // Update is called once per frame
    void Update()
    {
        if (isHit == true)
			{
                Target.GetComponent<RangeTarget>().isHit = true;
                ShootingRangeScript.iHitBoxPoints = bonusPoints;
                isHit = false;
			}
    }
}
