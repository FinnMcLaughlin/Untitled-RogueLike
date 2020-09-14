using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCharacter : MonoBehaviour {

	private bool bossSpawned;
	private bool playerSpawned = false;
	private GameObject spawnPoint;
	public GameObject player;

	void Start(){
		spawnPoint = GameObject.FindGameObjectWithTag ("Respawn");	
	}

	void Update(){
		if (!playerSpawned) {
			bossSpawned = GameObject.FindGameObjectWithTag ("Rooms").GetComponent<RoomTemplate> ().bossSpawned;

			if (bossSpawned) {
				Vector3 respawnPos = spawnPoint.transform.position;
				Destroy(spawnPoint);
				Instantiate (player, respawnPos, Quaternion.identity);
				playerSpawned = true;
			}
		}
	}
}
