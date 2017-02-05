using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
	public float spawnInterval = 3.0f;
	public GameObject box;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBox", 0f, spawnInterval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBox(){
		
		//check if game is over?
		Instantiate (box, spawnPoint.position, spawnPoint.rotation);
	}
	
}
