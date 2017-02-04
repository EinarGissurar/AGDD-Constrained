using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {
    [SerializeField]
    GameObject spawnPrefab;

    [SerializeField]
    float spawnRate;

    float timeOfSpawn = 5;

	// Use this for initialization
	void Start () {
        timeOfSpawn = Time.time + timeOfSpawn;	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= timeOfSpawn)
        {
            Debug.Log("Spawn!");
            Instantiate(spawnPrefab, transform.position, transform.rotation);
            timeOfSpawn = Time.time + timeOfSpawn;
        }
	}
}
