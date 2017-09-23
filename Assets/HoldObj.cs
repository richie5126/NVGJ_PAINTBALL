using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObj : MonoBehaviour {

	// Use this for initialization


	public GameObject holdLocation;
	public KeyCode holdKey = KeyCode.E;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider other)
	{
		
	}
	public void OnTriggerStay(Collider other)
	{
		Debug.Log ("In Range");
		if (other.gameObject.transform.GetComponent<Rigidbody2D> () != null && Input.GetKey(holdKey)) {
			other.gameObject.transform.parent = transform;
			other.gameObject.transform.position = holdLocation.transform.position;
		}
		else other.gameObject.transform.parent = transform.root;
	}
}
