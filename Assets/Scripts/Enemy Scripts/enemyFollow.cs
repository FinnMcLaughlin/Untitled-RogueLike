using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to follow  the player
public class enemyFollow : MonoBehaviour {

	public float movementSpeed;
	private Transform target;

	// Get the player's Transform information
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	void Update () {
		// Move towards player position until the distance is equal to the players scale (and so
		// it will not overlap the player sprite, but the player can overlap the enemy)
		if (Vector2.Distance (transform.position, target.position) > target.transform.localScale.x) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, movementSpeed * Time.deltaTime);
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			//print ("Touching at " + transform.position.x + " " + transform.position.y);
		}
	}
}
