using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	private float bulletSpeed = 10f;
	private Rigidbody2D rb;

	// Initialize bullet's rigidbody, and destroy bullet after 1s
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Invoke ("destroyBullet", 1f);
	}
	
	void Update () {
		// Move the bullet in a direction based on the speed
		rb.velocity = transform.right * bulletSpeed;
	}

	// Destroy bullet game object
	void destroyBullet(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		// If player bullet collides with enemy, destroy bullet
		if (gameObject.tag == "playerAttack" && other.CompareTag ("Enemy")) {
			destroyBullet ();
		}

		// If enemy bullet collides with player, destroy bullet
		if (gameObject.tag == "enemyAttack" && other.CompareTag ("Player")) {
			destroyBullet ();
		}
	}
}
