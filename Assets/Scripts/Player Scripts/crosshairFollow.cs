﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairFollow : MonoBehaviour {

	private Camera cam;

	public Transform firePoint;
	public GameObject bulletToFire;
	public float manaValue;
	private float coolDownTimer;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		coolDownTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Cursor.visible = false;
		Vector3 MousePos = Input.mousePosition;

		Vector3 Screenpoint = cam.WorldToScreenPoint (transform.localPosition);

		Vector2 Offset = new Vector2 (MousePos.x - Screenpoint.x, MousePos.y - Screenpoint.y);

		float angle = Mathf.Atan2 (Offset.y, Offset.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0f, 0f, angle);

		checkCooldownTimer ();

		if (Input.GetMouseButtonDown (0) && coolDownTimer == 0) {
			Instantiate (bulletToFire, firePoint.position, transform.rotation);
			coolDownTimer = manaValue;
		}
	}


	void checkCooldownTimer(){
		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		} else {
			coolDownTimer = 0;
		}
	}
}
