using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour {

	public float destroyTimer;

	// Destroy self after specified time
	void Start () {
		Destroy (gameObject, destroyTimer);
	}
}
