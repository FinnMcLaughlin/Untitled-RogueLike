using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	private EnemySpawnTemplate templates;
	private int rand;
	private bool spawned = false;

	void Start () {
		Destroy (gameObject, 4f);
		templates = GameObject.FindGameObjectWithTag ("Rooms").GetComponent<EnemySpawnTemplate> ();
		Invoke ("Spawn", 0.4f);
	}

	//Spawn a random enemy from the enemies list
	void Spawn(){
		rand = Random.Range (0, templates.enemies.Length);

		Instantiate (templates.enemies [rand], transform.position, Quaternion.identity);
	}
}
