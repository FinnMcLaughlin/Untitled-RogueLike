using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeAttack : MonoBehaviour {

	public float enemyAttack_CooldownTime;
	private float coolDownTimer;
	private int hits;

	// Use this for initialization
	void Start () {
		hits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		checkCooldownTimer ();
	}

	void checkCooldownTimer(){
		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		} else {
			coolDownTimer = 0;
		}
	}

	// BUG: When player + mouse are not moving, this trigger doesnt get called
	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player") && coolDownTimer == 0) {
			hits++;
			print ("Player hit; " + hits); 
			coolDownTimer = enemyAttack_CooldownTime;
		}
	}
}
