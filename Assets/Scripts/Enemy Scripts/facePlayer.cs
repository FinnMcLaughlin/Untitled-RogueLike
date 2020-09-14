using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour {

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 Offset = new Vector2 (target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
		float angle = Mathf.Atan2 (Offset.y, Offset.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0f, 0f, angle);
	}
}
