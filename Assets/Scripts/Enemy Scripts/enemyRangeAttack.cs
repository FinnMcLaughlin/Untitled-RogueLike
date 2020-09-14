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


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		coolDownTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		checkCooldownTimer ();
		//&& Vector2.Distance(transform.position, target.transform.position) < 5
		if (coolDownTimer == 0 && Vector2.Distance(transform.position, target.transform.position) <= rangeDistance) {
			Instantiate (bulletToFire, firePoint.position, transform.rotation);
			coolDownTimer = fireRate;
		}
	}


	void checkCooldownTimer(){
		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		} else {
			coolDownTimer = 0;
		}
	}
}
