using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredGround : MonoBehaviour {

	// Use this for initialization
	public int state = 0;
	public Color color;
	void Start () {
		GetComponent<SpriteRenderer> ().color = color;
		if (state > 3 || state < 0)
			state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals ("Player")) {
			if (state != 0)
				other.gameObject.GetComponent<playerControl> ().ChangeColor (state);
			else {
				state = other.gameObject.GetComponent<playerControl> ().getCurrentState ();
				color = other.gameObject.GetComponent<playerControl> ().getCurrentColor ();
				GetComponent<SpriteRenderer> ().color = color;
			}
		}
	}
}
