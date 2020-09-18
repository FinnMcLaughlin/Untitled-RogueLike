using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour {

	private Transform target;
	private bool playerSpawned = false;

	void Update () {
		if (playerSpawned) {
			// Rotate enemy based on position of Player
			Vector2 Offset = new Vector2 (target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
			float angle = Mathf.Atan2 (Offset.y, Offset.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.Euler (0f, 0f, angle);
		}
		else {
			
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
				playerSpawned = true;
			}
		}
	}
}
