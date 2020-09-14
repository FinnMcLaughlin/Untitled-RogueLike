using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRangeAttack : MonoBehaviour {

	public GameObject bulletToFire;
	public Transform firePoint;
	private float coolDownTimer;
	public float fireRate;
	public float rangeDistance;
	private Transform target;

	// Get Player position and initalize cool down timer
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		coolDownTimer = 0;
	}
	
	void Update () {
		
		checkCooldownTimer ();

		// Fire bullet towards Player if cool down timer allows it and if the distance between player and enemy is
		// within range. Reset the cooldown timer after firing bullet
		if (coolDownTimer == 0 && Vector2.Distance(transform.position, target.transform.position) <= rangeDistance) {
			Instantiate (bulletToFire, firePoint.position, transform.rotation);
			coolDownTimer = fireRate;
		}
	}

	//Basic cool down timer
	void checkCooldownTimer(){
		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		} else {
			coolDownTimer = 0;
		}
	}
}
