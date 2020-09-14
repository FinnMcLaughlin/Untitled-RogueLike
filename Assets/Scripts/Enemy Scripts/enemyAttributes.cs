using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttributes : MonoBehaviour {

	public int enemyHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("playerAttack")){
			enemyHealth--;
		}
	}
}
