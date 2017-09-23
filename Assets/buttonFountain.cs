using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFountain : MonoBehaviour {

    public ToggleFountain fountain;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
        {
            fountain.Toggle();
        }
    }
}
