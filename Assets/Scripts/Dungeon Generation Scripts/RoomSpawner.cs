using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	//1-> Rooms with an entrance at the bottom
	//2-> Rooms with an entrance at the top
	//3-> Rooms with an entrance at the right
	//4-> Rooms with an entrance at the left

	private RoomTemplate templates;
	private int rand;
	public bool spawned = false;

	public float waitTime_destroySpawners = 4f;

	void Start(){
		Destroy (gameObject, waitTime_destroySpawners);
		templates = GameObject.FindGameObjectWithTag ("Rooms").GetComponent<RoomTemplate> ();
		Invoke ("Spawn", 0.1f);
	}

	void Spawn(){
		if (spawned == false) {
			if (transform.position.x > -25 && transform.position.x < 25 && transform.position.y > -25 && transform.position.y < 25) {
				print ("Spawn");
				switch (openingDirection) {
				case 1:
					//spawn room with up entrance
					rand = Random.Range (0, templates.downRooms.Length);
					Instantiate (templates.downRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				case 2:
					//spawn room with down entrance
					rand = Random.Range (0, templates.upRooms.Length);
					Instantiate (templates.upRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				case 3:
					//spawn room with left entrance
					rand = Random.Range (0, templates.rightRooms.Length);
					Instantiate (templates.rightRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				case 4:
					//spawn room with right entrance
					rand = Random.Range (0, templates.leftRooms.Length);
					Instantiate (templates.leftRooms [rand], transform.position, Quaternion.identity);
					spawned = true;
					break;
				}


			} else {
				Instantiate (templates.closedRooms [openingDirection - 1], transform.position, Quaternion.identity);
				spawned = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("SpawnPoint")) {
			if (other.GetComponent<RoomSpawner> ().spawned == true) {
				//Destroy (gameObject);
				/*if (spawned == false) {
					Instantiate (templates.closedRooms [openingDirection - 1], transform.position, Quaternion.identity);
					Destroy (gameObject);
				} else {
					Destroy (gameObject);
				}*/
			} 
			spawned = true;
		}
	}
}
