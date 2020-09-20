using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPlayerEnter : MonoBehaviour {

	private EnemySpawnTemplate enemy_templates;
	private bool enemiesSpawned;
	private int rand;

	void Start () {
		enemiesSpawned = false;
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		// If the player enters the bounding box of the room, instatiate 
		// a random enemy spawner layout from RoomTemplate, and destroy the
		// room spawner object
		if (other.CompareTag ("Player") && !enemiesSpawned) {
			enemy_templates = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<EnemySpawnTemplate> ();

			rand = Random.Range (0, enemy_templates.spLayouts.Length);
			Instantiate (enemy_templates.spLayouts [rand], transform.position, Quaternion.identity);


			// Goes through each child of the room to find each lock game object
			// and call it's function to lock the room until the player kills
			// all enemies
			foreach(Transform child in transform){
				if (child.gameObject.tag == "roomLock") {
					child.GetComponent<LockRoom> ().lockRoom ();
				}
			}

			enemiesSpawned = true;
		}
	}
}
