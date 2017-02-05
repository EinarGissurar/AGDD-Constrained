using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grabable : MonoBehaviour {

    Rigidbody2D rigidBody;

    [SerializeField]
    float mass;
    public float Mass { get { return mass; } set { mass = value; } }

    void Awake()
    {
        AddRigidBody();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grab()
    {
        RemoveRigidBody();
        
    }

    public void Drop()
    {
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.mass = mass;
    }

    private void RemoveRigidBody()
    {
        Destroy(rigidBody);
    }
}
