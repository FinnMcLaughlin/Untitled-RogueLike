using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour {

	public float movementSpeed;
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
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
