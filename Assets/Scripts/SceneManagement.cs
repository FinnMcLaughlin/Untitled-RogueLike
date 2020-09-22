using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
	
	void nextLevel(){
		SceneManager.LoadScene (0);
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.CompareTag("Player")){
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<cameraFollow> ().resetCamera ();
			nextLevel();
		}
	}

}
