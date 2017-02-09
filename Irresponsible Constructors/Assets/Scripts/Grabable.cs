using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GrabAction();
public delegate void DropAction();

public class Grabable : MonoBehaviour {

    Rigidbody2D rigidBody;

    [SerializeField]
    float mass;

    public float Mass { get { return mass; } set { mass = value; } }

    public event GrabAction GrabEvent;
    public event DropAction DropEvent;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grab()
    {
        if (GrabEvent != null)
            GrabEvent();
    }

    public void Drop()
    {
        if (DropEvent != null)
            DropEvent();
    }
}
