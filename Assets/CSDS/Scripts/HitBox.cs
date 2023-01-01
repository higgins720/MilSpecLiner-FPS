using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;

    [SerializeField]
    private int bonusPoints;

    public AudioSource audioSource;

    public AudioClip hit;

    [HideInInspector]
	public bool isHit = false;

    void Start() {
        audioSource.GetComponent<AudioSource>().clip = hit;
    }

    void Update()
    {
        if (isHit == true)
			{
                
                audioSource.PlayOneShot(hit, 0.7f);

                Target.GetComponent<RangeTarget>().isHit = true;
                ShootingRangeScript.iHitBoxPoints = bonusPoints;
                isHit = false;
			}
    }
}
