using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Raycasting : MonoBehaviour {

	HandModel hand_model;
	Hand leap_hand;


	public GameObject teleport1;
	public GameObject teleport2;
	public GameObject teleport3;
	public GameObject teleport4;

	public Transform teleportLocation;



	void Start() 
	{
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");
	}

	void Update() 
	{
		for (int i = 0; i < HandModel.NUM_FINGERS;i++)
		{
			RaycastHit hit;
			FingerModel finger = hand_model.fingers[i];
			// draw ray from finger tips (enable Gizmos in Game window to see)

			Ray fingerRay = new Ray(finger.GetTipPosition(), finger.GetRay().direction);
			Debug.DrawRay(finger.GetTipPosition(), finger.GetRay().direction, Color.red); 

			if (Physics.Raycast (fingerRay, out hit)) {
				if (hit.collider.tag == "Teleport" && Input.GetKeyDown(KeyCode.E)) {
					Debug.Log ("this hit the teleport cube 1");
					teleportLocation.transform.position = teleport1.transform.position;
					teleportLocation.transform.rotation = teleport1.transform.rotation;
			}
				else if (hit.collider.tag == "Teleport 2" && Input.GetKeyDown(KeyCode.E)) {
					Debug.Log ("this hit the teleport cube 2");
					teleportLocation.transform.position = teleport2.transform.position;
					teleportLocation.transform.rotation = teleport2.transform.rotation;
				}
				else if (hit.collider.tag == "Teleport 3" && Input.GetKeyDown(KeyCode.E)) {
					Debug.Log ("this hit the teleport cube 3");
					teleportLocation.transform.position = teleport3.transform.position;
					teleportLocation.transform.rotation = teleport3.transform.rotation;
				}
				else if (hit.collider.tag == "Teleport 4" && Input.GetKeyDown(KeyCode.E)) {
					Debug.Log ("this hit the teleport cube 4");
					teleportLocation.transform.position = teleport4.transform.position;
					teleportLocation.transform.rotation = teleport4.transform.rotation;
				}


			}
		}
	}
}
