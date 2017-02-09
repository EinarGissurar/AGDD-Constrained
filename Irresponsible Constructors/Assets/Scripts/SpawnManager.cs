using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
	public float spawnInterval = 10.0f;
	public GameObject box;
	public Transform spawnPoint;
	public float[] challenges = {1,2,3,4};

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBox", 5f, spawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBox(){
		
		//check if game is over?
		GameObject temp = Instantiate (box, spawnPoint.position, spawnPoint.rotation);
	}
	
}
