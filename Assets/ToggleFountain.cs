using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFountain : MonoBehaviour {
	public int state = 0;
	public float toggleTime = 5.0f;

	private float timer;

	private BoxCollider2D[] paintTriggers;
	private ParticleSystem ps;

	void Start () {
		paintTriggers = gameObject.GetComponents<BoxCollider2D> ();
		ps = gameObject.GetComponent<ParticleSystem> ();
		if (state > 3 || state < 0)
			state = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= toggleTime) {
			Toggle ();
			timer = 0.0f;
		}
	}

	void Toggle()
	{
		ParticleSystem.EmissionModule em = ps.emission;
		em.enabled = !em.enabled;
		foreach(BoxCollider2D b in paintTriggers)
		{
			if(b.isTrigger)
			b.enabled = !b.enabled;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("Player") && state != 0)
			other.gameObject.GetComponent<playerControl> ().ChangeColor (state);
	}
}
