using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (audioSource.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void LoadGame()
	{
		SceneManager.LoadSceneAsync ("Tutorial2ElectricBoogaloo");	
	}
	public void QuitGame()
	{
		Application.Quit ();
	}
}
