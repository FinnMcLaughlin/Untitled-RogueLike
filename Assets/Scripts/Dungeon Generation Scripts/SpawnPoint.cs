using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for spawning for first room, player, and camera
public class SpawnPoint : MonoBehaviour {

	public Camera camera;

	// Instantiate the main camera in the middle of the first room
	void Start(){
		if (GameObject.FindGameObjectWithTag ("MainCamera") == null) {
			Instantiate (camera, new Vector3(transform.position.x, transform.position.y, -10f), Quaternion.identity);
			enableCamera ();
			camera.orthographicSize = 9.5f;
		}
		else {
			disableCamera ();
			Invoke ("enableCamera", 1f);
		}
	}

	void enableCamera(){
		camera.enabled = true;
	}

	void disableCamera(){
		camera.enabled = false;
	}

	// Any room that attempts to spawn on top of this spawner is destroyed
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") == false) {
			Destroy (other.gameObject);
		}
	}
}
