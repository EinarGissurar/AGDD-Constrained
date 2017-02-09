using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//temp gamemanager mock while waiting for other code..
public class CrateReturn : MonoBehaviour {
	public float score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		score++;
		Debug.Log (" Entered conveyor");
		Debug.Log (score);

	}


}
