using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMove : MonoBehaviour {
	public float velocity = 3f;
	// Use this for initialization
	void Update(){
	}

	//void OnCollisionStay2D(

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.name + " Entered conveyor");

	}
	void OnCollisionStay2D(Collision2D col){
		Debug.Log (col + " is on conveyor");
		Debug.Log (col.rigidbody.velocity.magnitude);
		col.rigidbody.AddForce(Vector2.right * velocity);	
		if (col.rigidbody.velocity.magnitude > 0.15) {
			col.rigidbody.velocity = col.rigidbody.velocity.normalized * 0.15f;

			//col.rigidbody.velocity.Normalize ();
			//col.rigidbody.velocity.Scale (Vector2.right);
		}
		//col.transform.position
		//col.transform.position += Vector2.right;

	}

	void OnTriggerLeave2D(Collider2D col){
		Debug.Log (col.name + " left conveyor");

	}
}
