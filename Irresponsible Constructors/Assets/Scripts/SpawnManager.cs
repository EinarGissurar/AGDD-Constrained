using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public float spawnInterval = 2.0f;
	public GameObject box;
	public Transform spawnPoint;
	//private List<float> challenges = new {1,2,3,4};
	private int challenge = 1;//start with 1 box already on screen
	private int spawns = 0;
	private int currentlySpawned = 0;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("SpawnBox", 5f, spawnInterval);
		//SpawnBox();
		//TriggerNextSpawn();//skip since first box should already be spawned?
		onEnable();//need to disable or it might memory leak?
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBox(){
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
		if (currentlySpawned != 0)
			return;
		
		challenge++;
		Debug.Log (challenge);
		currentlySpawned = challenge;
		spawns = challenge;
		InvokeRepeating ("SpawnBox", 0f, spawnInterval);
	}

	void onEnable(){
		CubeReturn.onCubeReturned += TriggerNextSpawn;
	}
	void onDisable(){
		CubeReturn.onCubeReturned -= TriggerNextSpawn;
	}
	
}
