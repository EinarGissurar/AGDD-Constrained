using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMove : MonoBehaviour {
	public float velocity = 1000000.5f;
	// Use this for initialization
	void Update(){
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.name + " Entered conveyor");

	}
	void OnTriggerStay2D(Collider2D col){
		Debug.Log (col.name + " is on conveyor");
		Debug.Log (col.attachedRigidbody);
		col.attachedRigidbody.AddForce (Vector2.up * velocity);
		//col.transform.position
		//col.transform.position += transform.forward * velocity * Time.deltaTime;

	}

	void OnTriggerLeave2D(Collider2D col){
		Debug.Log (col.name + " left conveyor");

	}
}
