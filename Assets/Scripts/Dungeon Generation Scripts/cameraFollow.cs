using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	private bool playerFound = false;
	private GameObject player;
	public float cameraBoundsX;
	public float cameraBoundsY;

	void Update(){
		// If the player leaves the bounds of the camera, then the camera shifts
		// position to the next room to follow the player
		if (playerFound) {
			if (player.transform.position.x < transform.position.x - cameraBoundsX) {
				transform.Translate (-10f, 0f, 0f);
			}

			if (player.transform.position.x > transform.position.x + cameraBoundsX) {
				transform.Translate (10f, 0f, 0f);
			}

			if (player.transform.position.y < transform.position.y - cameraBoundsY) {
				transform.Translate (0f, -10f, 0f);
			}

			if (player.transform.position.y > transform.position.y + cameraBoundsY) {
				transform.Translate (0f, 10f, 0f);
			}
		} 
		// If the player has not been found (i.e. not spawned) then keep 
		// looking for the player until it has spawned, and assign it to the game object
		else {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				player = GameObject.FindGameObjectWithTag ("Player");
				playerFound = true;
			}
		}
	}
}
