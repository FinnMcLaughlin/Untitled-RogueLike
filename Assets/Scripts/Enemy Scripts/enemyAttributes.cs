using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttributes : MonoBehaviour {

	public int enemyHealth;
	public float damageBuffer;

	void Update () {
		// Destroy enemy if health is 0
		if (enemyHealth < 1) {
			Destroy (gameObject);
		}
	}

	void takeDamage(){
		gameObject.GetComponent<Collider2D> ().enabled = true;
	}
		
	void OnTriggerEnter2D(Collider2D other){
		// Decrease enemy health if hit with player attack
		if(other.CompareTag("playerAttack")){
			gameObject.GetComponent<Collider2D> ().enabled = false;
			enemyHealth--;
			Invoke ("takeDamage", damageBuffer);
		}
	}
}
