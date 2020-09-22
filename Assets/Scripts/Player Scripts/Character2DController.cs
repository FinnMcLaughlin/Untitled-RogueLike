using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour {

	public float movementSpeed = 1;
	private Rigidbody2D rb;
	private Vector2 movementVelocity;
	private bool loadingPlayer = false;

	// Initialize Player's rigidbody
	void Start(){
		rb = GetComponent<Rigidbody2D> ();	
	}

	void Update(){
		if (loadingPlayer) {
			// Get input from player and create the player movement velocity based on direction and speed
			Vector2 movementInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			movementVelocity = movementInput.normalized * movementSpeed;
		}
		else {
			Invoke ("LoadedPlayer", 1f);
		}
	}

	void LoadedPlayer(){
		loadingPlayer = true;
	}

	void FixedUpdate(){
		// Move player based on the players position, the velocity
		rb.MovePosition (rb.position + movementVelocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("enemyAttack")){
			//print("Player Hit Ranged");
		}
	}
}
