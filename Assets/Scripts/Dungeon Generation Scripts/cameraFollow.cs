using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	private bool playerFound = false;
	private GameObject player;

	void Update(){
		if (playerFound) {
			if (player.transform.position.x < transform.position.x - 4.5) {
				transform.Translate (-10f, 0f, 0f);
			}

			if (player.transform.position.x > transform.position.x + 4.5) {
				transform.Translate (10f, 0f, 0f);
			}

			if (player.transform.position.y < transform.position.y - 4.5) {
				transform.Translate (0f, -10f, 0f);
			}

			if (player.transform.position.y > transform.position.y + 4.5) {
				transform.Translate (0f, 10f, 0f);
			}
		} else {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				player = GameObject.FindGameObjectWithTag ("Player");
				playerFound = true;
			}
		}
	}
}
