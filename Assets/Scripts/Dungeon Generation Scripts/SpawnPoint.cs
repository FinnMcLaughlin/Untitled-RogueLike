﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for spawning for first room, player, and camera
public class SpawnPoint : MonoBehaviour {

	public Camera camera;

	// Instantiate the main camera in the middle of the first room
	void Start(){
		Instantiate (camera, new Vector3(transform.position.x, transform.position.y, -10f), Quaternion.identity);
		camera.enabled = true;
	}

	// Any room that attempts to spawn on top of this spawner is destroyed
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") == false) {
			Destroy (other.gameObject);
		}
	}
}