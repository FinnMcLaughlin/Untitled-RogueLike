using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCharacter : MonoBehaviour {

	private bool bossSpawned;
	private bool playerSpawned = false;
	private GameObject spawnPoint;
	public GameObject player;

	// Find the spawnPoint within the game
	void Start(){
		spawnPoint = GameObject.FindGameObjectWithTag ("Respawn");	
	}

	void Update(){
		if (!playerSpawned) {
			bossSpawned = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<RoomTemplate> ().bossSpawned;

			if (bossSpawned) {
				// If the player has not been spawned and the boss has
				// Get position of spawn point, destroy it, and
				// instatiate the player
				Vector3 respawnPos = spawnPoint.transform.position;
				Destroy(spawnPoint);
				Instantiate (player, respawnPos, Quaternion.identity);
				playerSpawned = true;
			}
		}
	}
}
