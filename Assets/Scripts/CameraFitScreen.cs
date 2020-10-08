using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFitScreen : MonoBehaviour {

	public GameObject room;

	void Start () {
		//float orthoSize = room.transform.localScale.x * Screen.height / Screen.width * 0.5f;

		Camera.main.orthographicSize = 9.5f;
	}
}
