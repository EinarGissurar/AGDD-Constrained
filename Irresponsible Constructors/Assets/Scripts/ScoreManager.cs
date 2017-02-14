using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int newScore;
	private int score;
	private bool gameOver;

	[SerializeField]
	GameManager gameManager;

	Text text;

	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		text = GetComponent<Text> ();
		score = 0;
		newScore = 0;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateScore();

	}

	void updateScore(){
		if(!gameOver){
			score =  newScore;
			text.text = "SCORE: " + score.ToString("D2");
		}
	}

	void OnEnable()
	{
		if (gameManager != null) {
			gameManager.PlayersWinEvent += OnGameOver;
			gameManager.PlayersLoseEvent += OnGameOver;
		}
	}

	void OnDisable()
	{
		if (gameManager != null) {
			gameManager.PlayersWinEvent -= OnGameOver;
			gameManager.PlayersLoseEvent -= OnGameOver;
		}
	}

	private void OnGameOver() 
	{
		gameOver = true;
	}

}
