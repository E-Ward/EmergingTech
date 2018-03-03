using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantSpawner : MonoBehaviour {

	public GameObject elephant;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.L)) {
			Instantiate (elephant, new Vector3 (5, 7, -2), Quaternion.identity);
		}

	}
}
