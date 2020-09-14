using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	public Camera camera;

	void Start(){
		Instantiate (camera, new Vector3(transform.position.x, transform.position.y, -10f), Quaternion.identity);
		camera.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player") == false) {
			Destroy (other.gameObject);
		}
	}
}
