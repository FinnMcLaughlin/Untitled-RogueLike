using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour {

	public GameObject[] upRooms;
	public GameObject[] downRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject[] closedRooms;

	public List<GameObject> rooms;

	public float waitTime;
	public GameObject boss;
	public bool bossSpawned = false;

	void Update(){
		if(!bossSpawned){
			if (waitTime <= 0) {
				Instantiate (boss, rooms [rooms.Count - 1].transform.position, Quaternion.identity);
				bossSpawned = true;
			} 
			else {
				waitTime -= Time.deltaTime;
			}
		}
	}
}
