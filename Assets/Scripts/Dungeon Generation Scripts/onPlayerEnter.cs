using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPlayerEnter : MonoBehaviour {

	private EnemySpawnTemplate enemy_templates;
	private bool enemiesSpawned;
	public bool playerInCurrentRoom;
	public bool bossRoom;
	private int rand;

	void Start () {
		enemiesSpawned = false;
	}

	public void makeBossRoom(){
		bossRoom = true;
		gameObject.tag = "BossRoom";
	}

	public bool isBossRoom(){
		print ("Boss Room: " + bossRoom); 
		return bossRoom;
	}

	public bool isPlayerInCurrentRoom(){
		print ("Player In Current Room: " + playerInCurrentRoom); 
		return playerInCurrentRoom;
	}


	void spawnEnemies(){
		// If the player enters the bounding box of the room, instatiate 
		// a random enemy spawner layout from RoomTemplate, and destroy the
		// room spawner object
		enemy_templates = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<EnemySpawnTemplate> ();

		rand = Random.Range (0, enemy_templates.spLayouts.Length);
		Instantiate (enemy_templates.spLayouts [rand], transform.position, Quaternion.identity);
	}

	void spawnBoss(){
		EnemySpawnTemplate boss_enemy = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<EnemySpawnTemplate> ();

		rand = Random.Range (0, boss_enemy.enemies.Length);
		Instantiate (boss_enemy.enemies [rand], transform.position, Quaternion.identity).transform.localScale = new Vector3(1.5f, 1.5f, 0f);
	}

	void lockRoom(){
		// Goes through each child of the room to find each lock game object
		// and call it's function to lock the room until the player kills
		// all enemies
		foreach(Transform child in transform){
			if (child.gameObject.tag == "roomLock") {
				child.GetComponent<LockRoom> ().lockRoom ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") && !enemiesSpawned) {
				if (isBossRoom()) {
					spawnBoss ();
				} 
				else {
					spawnEnemies ();
				}

				lockRoom ();

				enemiesSpawned = true;
			}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			playerInCurrentRoom = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			playerInCurrentRoom = false;
		}
	}
}
