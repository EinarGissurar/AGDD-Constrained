using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//temp gamemanager mock while waiting for other code..
public class CubeReturn : MonoBehaviour {
	public float score;

	public delegate void CubeReturned();
	public static event CubeReturned onCubeReturned;
	private List<int> cubesReturned = new List<int>();

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		//col.gameObject.GetInstanceID ();

		if (onCubeReturned != null && !cubesReturned.Contains(col.gameObject.GetInstanceID ())) {
			cubesReturned.Add (col.gameObject.GetInstanceID ());
			onCubeReturned ();
			score++;
			Debug.Log (" Entered conveyor");
			Debug.Log (score);
		}

	}


}
