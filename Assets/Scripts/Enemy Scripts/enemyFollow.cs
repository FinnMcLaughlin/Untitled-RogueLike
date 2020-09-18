using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to follow  the player
public class enemyFollow : MonoBehaviour {

	public float movementSpeed;
	private Transform target;
	private bool playerSpawned = false;

	// Get the player's Transform information
	void Start () {
		
	}
	
	void Update () {

		if (playerSpawned) {
			// Move towards player position until the distance is equal to the players scale (and so
			// it will not overlap the player sprite, but the player can overlap the enemy)
			if (Vector2.Distance (transform.position, target.position) > target.transform.localScale.x) {
				transform.position = Vector2.MoveTowards (transform.position, target.position, movementSpeed * Time.deltaTime);
			}
		} else {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
				playerSpawned = true;
			}
		}

	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			//print ("Touching at " + transform.position.x + " " + transform.position.y);
		}
	}
}
