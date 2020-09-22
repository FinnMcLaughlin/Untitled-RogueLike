using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttributes : MonoBehaviour {

	public bool playerSpawned;
	public int playerHealth;

	// Use this for initialization
	void Start () {
		playerSpawned = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth < 1) {
			print ("YOU LOSE");
			SceneManager.LoadScene (1);
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("enemyAttack")){
			playerHealth--;
			print (playerHealth);
		}
	}
}
