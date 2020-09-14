using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour {

	public float movementSpeed = 1;
	private Rigidbody2D rb;
	private Vector2 movementVelocity;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();	
	}

	void Update(){
		Vector2 movementInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		movementVelocity = movementInput.normalized * movementSpeed;
	}

	void FixedUpdate(){
		rb.MovePosition (rb.position + movementVelocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("enemyAttack")){
			//print("Player Hit Ranged");
		}
	}
}
