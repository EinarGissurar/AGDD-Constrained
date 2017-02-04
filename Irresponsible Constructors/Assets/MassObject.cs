using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassObject : MonoBehaviour {

    [SerializeField]
    private int m_mass = 0;

    public int Mass { get { return m_mass; } set { m_mass = value; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
