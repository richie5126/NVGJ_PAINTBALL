﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportObject : MonoBehaviour {

	// Use this for initialization
	public string NextSceneName;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		SceneManager.LoadSceneAsync(NextSceneName);
	}
}
