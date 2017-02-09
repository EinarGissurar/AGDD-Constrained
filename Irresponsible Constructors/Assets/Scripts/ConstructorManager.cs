using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorManager : MonoBehaviour {

    [SerializeField]
    ConstructorController constructorController;

    Collider2D[] colliders;

    void Awake()
    {
        colliders = GetComponents<Collider2D>();
    }

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEnable()
    {
        Subscribe();
    }

    public void OnDisable()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        constructorController.BreakEvent += OnBreak;
    }

    private void UnSubscribe()
    {
        constructorController.BreakEvent -= OnBreak;
    }

    private void OnBreak()
    {
        UnSubscribe();
        Destroy(constructorController);

        foreach(var collider in colliders)
        {
            collider.enabled = true;
        }

        gameObject.AddComponent<Rigidbody2D>();
    }
}
