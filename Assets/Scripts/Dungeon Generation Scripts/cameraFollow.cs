using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	private bool playerFound = false;
	private GameObject player;
	public float cameraBoundsX;
	public float cameraBoundsY;
	public float cameraMoveDist;

	void Update(){
		// If the player leaves the bounds of the camera, then the camera shifts
		// position to the next room to follow the player
		if (playerFound) {
			if (player.transform.position.x < transform.position.x - cameraBoundsX) {
				transform.Translate (-cameraMoveDist, 0f, 0f);
			}

			if (player.transform.position.x > transform.position.x + cameraBoundsX) {
				transform.Translate (cameraMoveDist, 0f, 0f);
			}

			if (player.transform.position.y < transform.position.y - cameraBoundsY) {
				transform.Translate (0f, -cameraMoveDist, 0f);
			}

			if (player.transform.position.y > transform.position.y + cameraBoundsY) {
				transform.Translate (0f, cameraMoveDist, 0f);
			}
		} 
		// If the player has not been found (i.e. not spawned) then keep 
		// looking for the player until it has spawned, and assign it to the game object
		else {
			Invoke ("findPlayer", 1f);
		}
	}

	void findPlayer(){
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			print ("Player Found");
			player = GameObject.FindGameObjectWithTag ("Player");
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -cameraMoveDist);  
			playerFound = true;
		}
	}

	public void resetCamera(){
		playerFound = false;
	}
}
