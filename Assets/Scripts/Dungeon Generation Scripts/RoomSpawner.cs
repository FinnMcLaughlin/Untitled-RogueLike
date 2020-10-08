using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	//1-> Room Spawn point which is above the current room
	//2-> Room Spawn point which is below the current room
	//3-> Room Spawn point which is to the left of the current room
	//4-> Room Spawn point which is to the right of the current room

	private RoomTemplate room_templates;
	private EnemySpawnTemplate enemy_templates;
	private int rand;
	public bool spawned = false;
	int gridSize = 130;

	//public float waitTime_destroySpawners = 4f;

	// Destroy the Room Spawn after designated time
	// Get the rooms list from room template
	// Spawn the rooms 0.1s
	void Start(){
		room_templates = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<RoomTemplate> ();
		Invoke ("Spawn", 0.1f);
	}

	void Spawn(){
		GameObject room;

		// If the current room spawner has not spawned a room yet and the room spawner is within the dungeon bounds
		// Get the room spawners opening direction in order to decide from which rooms list to choose a random room from
		if (spawned == false) {
			if (transform.position.x > -gridSize && transform.position.x < gridSize && transform.position.y > -gridSize && transform.position.y < gridSize) {
				switch (openingDirection) {
				case 1:
					//spawn room with a door leading down
					rand = Random.Range (0, room_templates.downRooms.Length);
					Instantiate (room_templates.downRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				case 2:
					//spawn room with a door leading up
					rand = Random.Range (0, room_templates.upRooms.Length);
					Instantiate (room_templates.upRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				case 3:
					//spawn room with a door leading right
					rand = Random.Range (0, room_templates.rightRooms.Length);
					Instantiate (room_templates.rightRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				case 4:
					//spawn room with a door leading left
					rand = Random.Range (0, room_templates.leftRooms.Length);
					Instantiate (room_templates.leftRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				}
			}
			// If the room spawner is outside of the dungeon bounds, then spawn a "closed room", which has 
			// only one entrance/exit
			else {
				Instantiate (room_templates.closedRooms [openingDirection - 1], transform.position, Quaternion.identity);
				spawned = true;
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		// Check if the room spawn point is colliding with another room spawn point
		// If it is and that spawn point has been spawned then destroy the current spawn point
		// If it the other spawn point has not been spawned then destroy it
		if (other.CompareTag ("SpawnPoint")) {
			if (other.GetComponent<RoomSpawner> ().spawned == true) {
				//Destroy (gameObject);
			} else {
				//Destroy (other.gameObject);
			}
			spawned = true;
		}
	}
}
