using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFountain : MonoBehaviour {

	// Use this for initialization

	public int state = 0;

	void Start () {

		if (state > 3 || state < 0)
			state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Player") && state != 0)
			other.gameObject.GetComponent<playerControl> ().ChangeColor (state);
	}
}
