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
	private bool playerSpawned = false;

	// Get Player position and initalize cool down timer
	void Start () {
		coolDownTimer = 0;
	}
	
	void Update () {
		if (playerSpawned) {
			checkCooldownTimer ();

			// Fire bullet towards Player if cool down timer allows it and if the distance between player and enemy is
			// within range. Reset the cooldown timer after firing bullet
			if (coolDownTimer == 0 && Vector2.Distance(transform.position, target.transform.position) <= rangeDistance) {
				Instantiate (bulletToFire, firePoint.position, transform.rotation);
				coolDownTimer = fireRate;
			}
		}
		else {

			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
				playerSpawned = true;
			}
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
