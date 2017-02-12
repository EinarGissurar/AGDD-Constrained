using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void PlayersWin();
public delegate void PlayersLose();
public delegate void TimeOut();

public class GameManager : MonoBehaviour {

    [SerializeField]
    ConstructorController constructorController;

    public float startTimer;
    private float countDown;
    private float minutes;
    private float seconds;
    public Text timerText;

    private bool hasPlayed;
    private bool isGameOver;
    private bool timeLow;

    public Animator anim;

	public event PlayersWin PlayersWinEvent;
	public event PlayersLose PlayersLoseEvent;
	public event TimeOut TimeOutEvent;

	// Use this for initialization
	void Start () {
        countDown = startTimer;
        hasPlayed = false;
        timeLow = false;
        isGameOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;

        if (countDown <= 10) {
            if (!timeLow) {
                timeLow = true;
                anim.SetTrigger("TimeOut");
            }
        }

        if (countDown >= 0) {
            minutes = Mathf.Floor(countDown / 60);
            seconds = countDown % 60;
            timerText.text = string.Format("TIME: {0:0}:{1:00}", minutes, seconds);
        }
        else {
			if (!hasPlayed && !isGameOver) {
				if (TimeOutEvent != null)
					TimeOutEvent ();
				
				GameLost();
                hasPlayed = true;
            }
        }
	}

    public void OnEnable() {
        Subscribe();
    }

    public void OnDisable() {
        UnSubscribe();
    }

    private void Subscribe() {
        constructorController.BreakEvent += GameLost;
    }

    private void UnSubscribe() {
        constructorController.BreakEvent -= GameLost;
    }

    void GameLost() {
		isGameOver = true;
		UnSubscribe ();
        if (PlayersLoseEvent != null) {
            PlayersLoseEvent();
        }
        anim.SetTrigger("GameOver");
    }

    void GameWon() {
		isGameOver = true;
		UnSubscribe ();
        if (PlayersWinEvent != null) {
            PlayersWinEvent();
        }
        anim.SetTrigger("GameOver");
    }
}
