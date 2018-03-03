using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Phidgets;
using Phidgets.Events;




public class RFID_check : MonoBehaviour {

	public RFID rfid = new RFID(); //Declare an RFID object

	public GameObject itemToSpawn1;
	public GameObject itemToSpawn2;
	public GameObject itemToSpawn3;
	public GameObject itemToSpawn4;

	GameObject spawnedItem1;
	GameObject spawnedItem2;
	GameObject spawnedItem3;
	GameObject spawnedItem4;

	public bool destroyItem1 = false;
	public bool destroyItem2 = false;
	public bool destroyItem3 = false;
	public bool destroyItem4 = false;

	//public static string spawnedItem = "";


	// Use this for initialization
	void Start () {

		try
		{
			
			//initialize our Phidgets RFID reader and hook the event handlers
			rfid.Attach += new AttachEventHandler(rfid_Attach);
			rfid.Detach += new DetachEventHandler(rfid_Detach);
			rfid.Error += new ErrorEventHandler(rfid_Error);

			rfid.Tag += new TagEventHandler(rfid_Tag);
			rfid.TagLost += new TagEventHandler(rfid_TagLost);
			rfid.open();

			//Wait for a Phidget RFID to be attached before doing anything with the object
			Debug.Log("waiting for attachment...");
			rfid.waitForAttachment();

			//turn on the antenna and the LED
			rfid.Antenna = true;
			rfid.LED = true;


		}
		catch (PhidgetException ex)
		{
			Debug.Log(ex.Description);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyItem1) {

			Destroy (spawnedItem1.gameObject);
			spawnedItem1 = null;
			Debug.Log ("Elephant Despawned");
			destroyItem1 = false;
		}

		if (destroyItem2) {
			Destroy (spawnedItem2.gameObject);
			spawnedItem2 = null;
			Debug.Log ("Plant Despawned");
			destroyItem2 = false;
		}

		if (destroyItem3) {
			Destroy (spawnedItem3.gameObject);
			spawnedItem3 = null;
			Debug.Log ("Windmill Despawned");
			destroyItem3 = false;
		}

		if (destroyItem4) {
			Destroy (spawnedItem4.gameObject);
			spawnedItem4 = null;
			Debug.Log ("Church Despawned");
			destroyItem4 = false;
		}
	
	}


	//attach event handler...display the serial number of the attached RFID phidget
	static void rfid_Attach(object sender, AttachEventArgs e)
	{
		Debug.Log("RFIDReader {0} attached!" + e.Device.SerialNumber.ToString());
	}

	//detach event handler...display the serial number of the detached RFID phidget
	static void rfid_Detach(object sender, DetachEventArgs e)
	{
		Debug.Log("RFID reader {0} detached!" + e.Device.SerialNumber.ToString());
	}

	//Error event handler...display the error description string
	static void rfid_Error(object sender, ErrorEventArgs e)
	{
		Debug.Log(e.Description);
	}

	//Print the tag code of the scanned tag
	void rfid_Tag(object sender, TagEventArgs e)
	{
		Debug.Log("Tag {0} scanned " + e.Tag);

		if (e.Tag == "450013896c") {
			spawnedItem1 = Instantiate (itemToSpawn1, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (-91, 173, -79)));
			Debug.Log ("Elephant Spawned");
		} else if (e.Tag == "3f00609e94") {
			spawnedItem2 = Instantiate (itemToSpawn2, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (-90, 0, 0)));
			Debug.Log ("Plant Spawned");
		} else if (e.Tag == "124675") {
			spawnedItem3 = Instantiate (itemToSpawn3, new Vector3 (0, 0, 0), Quaternion.Euler (new Vector3 (0, 180, 0)));
			Debug.Log ("Windmill Spawned");
		} else if (e.Tag == "1237946") {
			spawnedItem4 = Instantiate (itemToSpawn4, new Vector3 (5, 0, 1), Quaternion.Euler (new Vector3 (0, 0, 0)));
			Debug.Log ("Church Spawned");
		}
		else {
			Debug.Log ("Invalid Tag");
		}
	}

	//print the tag code for the tag that was just lost
	void rfid_TagLost(object sender, TagEventArgs e)
	{

		Debug.Log ("Tag {0} lost " + e.Tag);

		if (e.Tag == "450013896c" && !destroyItem1) {
			destroyItem1 = true;
		}
		if (e.Tag == "3f00609e94" && !destroyItem2) {
			destroyItem2 = true;

		}
		if (e.Tag == "124675" && !destroyItem3) {
			destroyItem3 = true;

		}
		if (e.Tag == "1237946" && !destroyItem4) {
			destroyItem4 = true;

		}


	}


}
