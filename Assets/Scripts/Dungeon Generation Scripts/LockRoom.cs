using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRoom : MonoBehaviour {

	public bool roomLocked = false;
	private bool enemiesSpawned = false;
	private GameObject[] enemies;

	// When the room has been spawned, room lock is inactive to
	// allow for the player to enter the room initially
	void Start () {
		gameObject.SetActive (false);
	}

	// If the player has entered the room, the room is locked
	// and is subsequently unlocked when all enemies have been
	// killed
	void Update () {
		if (roomLocked) {
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			if (enemiesSpawned && enemies.Length < 1) {
				Destroy (gameObject);
			}

			if (!enemiesSpawned && enemies.Length > 0) {
				enemiesSpawned = true;
			}
		}
	}

	public void lockRoom(){
		gameObject.SetActive (true);
		roomLocked = true;
	}
}
