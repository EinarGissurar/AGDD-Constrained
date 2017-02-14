using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnManager : MonoBehaviour {

	[SerializeField]
	float intervalBetweenRounds = 10f;

	[SerializeField]
	float spawnInterval = 1f;

	[SerializeField]
	int minNumberOfSuppliesSpawned = 2;

	[SerializeField]
	int maxNumberOfSuppliesSpawned = 3;

	[SerializeField]
	int numberOfSuppliesAddedEachRound = 1;

	[SerializeField]
	float spawnTimeDeltaAddedEachRound = 0.2f;

	[SerializeField]
	GameObject[] supplies;

	[SerializeField]
	Transform spawnPoint;

	int numberOfSuppliesSpawned;

	bool isRoundOn = false;
	int suppliesReturned = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isRoundOn)
			StartCoroutine (StartRound());
	}

	IEnumerator StartRound() {
		isRoundOn = true;
		numberOfSuppliesSpawned = Random.Range (minNumberOfSuppliesSpawned, maxNumberOfSuppliesSpawned);
		for (int i = 0; i < numberOfSuppliesSpawned; i++) {
			GameObject supply = GetRandomSupplyType ();
			GameObject instance = Instantiate (supply, spawnPoint.position, spawnPoint.rotation);
			yield return new WaitForSeconds (Random.Range(1.0f, 3.0f));
		}

		float timeUntilNextSpawn = Time.time + intervalBetweenRounds;
		yield return new WaitForSeconds (intervalBetweenRounds); //WaitUntil (() => Time.time >= timeUntilNextSpawn || isRoundOn == false);
		TurnOffRoundWait ();
		UpdateSettings ();
		suppliesReturned = 0;
	}

	private GameObject GetRandomSupplyType() {
		// No randomness introduced at this point.
		return supplies [0];
	}

	private void UpdateSettings() {
		maxNumberOfSuppliesSpawned += maxNumberOfSuppliesSpawned < 4 ? numberOfSuppliesAddedEachRound : 0;
		spawnInterval -= spawnTimeDeltaAddedEachRound;
	}

	public void TurnOffRoundWait() {
		isRoundOn = false;
	}

	public void OnSupplyReturn() {
		suppliesReturned++;

		if (suppliesReturned == numberOfSuppliesSpawned)
			TurnOffRoundWait ();
	}

	public void OnEnable() {
		//CubeManager.onCubeReturned += OnSupplyReturn;
	}

	public void OnDisable() {
		//CubeManager.onCubeReturned -= OnSupplyReturn;
	}
}
