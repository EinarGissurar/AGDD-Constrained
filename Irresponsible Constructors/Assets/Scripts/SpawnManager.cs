using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public float spawnInterval = 5.0f;
	public GameObject box;
	public Transform spawnPoint;
	//private List<float> challenges = new {1,2,3,4};
	private int challenge = 0;
	private int spawns = 0;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("SpawnBox", 5f, spawnInterval);
		//SpawnBox();
		TriggerNextSpawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBox(){
		
		//Vector3 spawn = spawnPoint.position;
		//for (int i = 0; i < challenges [challenge]; i++) {
		//	Instantiate (box, spawn, spawnPoint.rotation);
		//	Debug.Log ("spawned box");
		//	Debug.Log (i);
		//	Debug.Log (challenges [challenge]);
		//	spawn.y += 15;
		//}
		if(spawns-- == 0){
			CancelInvoke ("SpawnBox");
			Debug.Log ("invoke was canceled");
			return;
		}
		//else
		Instantiate (box, spawnPoint.position, spawnPoint.rotation);
	}

	void TriggerNextSpawn(){
		Debug.Log ("spawn triggered");
		challenge++;
		Debug.Log (challenge);
		spawns = challenge;
		InvokeRepeating ("SpawnBox", 0f, spawnInterval);
	}


	
}
