using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeAttack : MonoBehaviour {

	public float enemyAttack_CooldownTime;
	private float coolDownTimer;

	void Start () {

	}
	
	void Update () {
		//checkCooldownTimer ();
	}

	// Basic cool down timer
	void checkCooldownTimer(){
		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		} else {
			coolDownTimer = 0;
		}
	}


	void OnTriggerStay2D(Collider2D other){
		// Does damage to player in intervals if the attack point is colliding
		// with the player
		// !!! BUG: When player + mouse are not moving, this trigger doesnt get called !!!
		if (other.CompareTag ("Player") && coolDownTimer == 0) {
			//coolDownTimer = enemyAttack_CooldownTime;
		}
	}
}
