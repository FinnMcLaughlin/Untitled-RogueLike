using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	private RoomTemplate templates;

	// Adds room to Room Template rooms list
	void Start(){
		templates = GameObject.FindGameObjectWithTag ("AllRooms").GetComponent<RoomTemplate> ();
		templates.rooms.Add (this.gameObject);
	}
}
