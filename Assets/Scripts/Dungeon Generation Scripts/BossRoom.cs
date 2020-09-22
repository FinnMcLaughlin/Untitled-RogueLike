using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour {

	public GameObject exitPortal;
	private bool bossDead;

	// Use this for initialization
	void Start () {
		bossDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (bossDead) {
			Instantiate (exitPortal, transform.position, Quaternion.identity);
			bossDead = false;
		}
	}

	public void BossKilled(){
		bossDead = true;
	}
}
