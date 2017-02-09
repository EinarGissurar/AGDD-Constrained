using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMove : MonoBehaviour {
	public float velocity = 3f;
	//public bool goal;
	//public delegate void PointAction();
	//public static event PointAction OnCrateReturned;
	// Use this for initialization
	void Update(){
	}

	//void OnCollisionStay2D(

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.name + " Entered conveyor");

	}
	void OnCollisionStay2D(Collision2D col){
		//Debug.Log (col + " is on conveyor");
		//Debug.Log (col.rigidbody.velocity.magnitude);
		col.rigidbody.AddForce(Vector2.right * velocity);
		if (col.rigidbody.velocity.magnitude > 0.15) {
			col.rigidbody.velocity = col.rigidbody.velocity.normalized * 0.15f;
		}
	}

	void OnTriggerLeave2D(Collider2D col){
		//Debug.Log (col.name + " left conveyor");

		/*if (goal) {
			OnCrateReturned ();
			//destroy gameobject?
		}*/


	}
}
