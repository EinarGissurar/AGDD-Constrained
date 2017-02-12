using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField]
	AudioSource musicSource;

	[SerializeField]
	AudioSource winSound;

	[SerializeField]
	AudioSource loseSound;

	[SerializeField]
	GameManager gameManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnEnable() 
	{
		if (gameManager != null) {
			gameManager.PlayersWinEvent += OnWin;
			gameManager.PlayersLoseEvent += OnLoss;
		}
	}

	void OnDisable() 
	{
		if (gameManager != null) {
			gameManager.PlayersWinEvent -= OnWin;
			gameManager.PlayersLoseEvent -= OnLoss;
		}
	}

	private void OnLoss() 
	{
		musicSource.Stop ();
		loseSound.Play ();
	}

	private void OnWin()
	{
		musicSource.Stop ();
		winSound.Play ();
	}
}
