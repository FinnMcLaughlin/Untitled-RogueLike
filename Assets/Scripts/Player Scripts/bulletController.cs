using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	private float bulletSpeed = 10f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Invoke ("destroyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = transform.right * bulletSpeed;
	}

	void destroyBullet(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (gameObject.tag == "playerAttack" && other.CompareTag ("Enemy")) {
			destroyBullet ();
		}

		if (gameObject.tag == "enemyAttack" && other.CompareTag ("Player")) {
			destroyBullet ();
		}
	}
}
