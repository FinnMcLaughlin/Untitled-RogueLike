using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughScene : MonoBehaviour {
	
	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

}
