using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float startTimer;
    private float countDown;
    private float minutes;
    private float seconds;
    public Text timerText;

    public Animator anim;

	// Use this for initialization
	void Start () {
        countDown = startTimer;
        //timerText = GetComponent<Text>();
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        countDown -= Time.deltaTime;
        minutes = Mathf.Floor(countDown / 60);
        seconds = countDown % 60;
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (countDown <= 0 || Input.GetKeyUp(KeyCode.Escape)) {
            print("GAME OVER!");
            anim.SetTrigger("GameOver");
        }
        print(countDown);
	}
}
