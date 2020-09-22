using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCharacter : MonoBehaviour {

	private bool bossSpawned;
	private bool playerSpawned;
	private bool playerRespawned = false;
	private GameObject spawnPoint;
	public GameObject player;

	// Find the spawnPoint within the game
	void Start(){
		spawnPoint = GameObject.FindGameObjectWithTag ("Respawn");
		HasPlayerSpawned ();
	}

	void Update(){
		if (!playerRespawned) {
			bossSpawned = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<RoomTemplate> ().bossSpawned;

			if (bossSpawned) {
				Vector3 respawnPos = spawnPoint.transform.position;
				Destroy(spawnPoint);

				if (playerSpawned) {
					RepositionPlayer (respawnPos);
				} else {
					// If the player has not been spawned and the boss has
					// Get position of spawn point, destroy it, and
					// instatiate the player
					Instantiate (player, respawnPos, Quaternion.identity);
					playerSpawned = true;
				}


				playerRespawned = true;
			}
		}
	}

	public void ActivePlayer(){
		GameObject.FindGameObjectWithTag ("Player").SetActive(true);
	}

	public void NonActivePlayer(){
		GameObject.FindGameObjectWithTag ("Player").SetActive(false);
	}

	public void RepositionPlayer(Vector3 pos){
		GameObject.FindGameObjectWithTag ("Player").transform.position = pos;
	}

	public void HasPlayerSpawned(){
		if (GameObject.FindGameObjectWithTag ("Player") == null) {
			playerSpawned = false;
		} else {
			playerSpawned = true;
		}
	}
}
