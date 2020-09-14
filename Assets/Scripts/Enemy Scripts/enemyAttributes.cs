using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttributes : MonoBehaviour {

	public int enemyHealth;

	void Start () {
		
	}

	void Update () {
		// Destroy enemy if health is 0
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		// Decrease enemy health if hit with player attack
		if(other.CompareTag("playerAttack")){
			enemyHealth--;
		}
	}
}
