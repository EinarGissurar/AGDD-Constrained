using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    Grabable grabableScript;

    [SerializeField]
    float floorOffset = 0.2f;

    [SerializeField]
    float dotThresholdBreak = 0.7f;

    [SerializeField]
    float forceMagnitudeAppliedToFloor = 9.8f;

    [SerializeField]
    float lerpSpeed = 0.1f;

    Rigidbody2D rigidBody;
    FloorController floorController;
    ConstructorController constructorController;
    Collider2D[] colliders;

    void Awake()
    {
        AddRigidBody();
        colliders = GetComponents<Collider2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(rigidBody != null)
            Debug.Log("Velocity:" + rigidBody.velocity);
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
        grabableScript.GrabEvent += OnGrab;
        grabableScript.DropEvent += OnDrop;
    }

    private void UnSubscribe()
    {
        grabableScript.GrabEvent -= OnGrab;
        grabableScript.DropEvent -= OnDrop;
    }

    private void AddRigidBody()
    {
        rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.mass = grabableScript.Mass;
    }

    private void RemoveRigidBody()
    {
        if (rigidBody != null)
            Destroy(rigidBody);
    }

    private void OnGrab()
    {
        Destroy(constructorController);
        constructorController.BreakEvent -= OnDrop;
    }

    private void OnDrop()
    {
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        SetCollidersActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (constructorController != null)
            return;

        floorController = collision.gameObject.GetComponent<FloorController>();

        if (floorController != null)
        {
            SetCollidersActive(false);
            rigidBody.bodyType = RigidbodyType2D.Kinematic;
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity = 0;
            constructorController = gameObject.AddComponent<ConstructorController>();
            constructorController.BreakEvent += OnDrop;
            constructorController.FloorController = floorController;
            constructorController.CalculatePositionLerpValue();
            constructorController.SetSettings(floorOffset, dotThresholdBreak, grabableScript.Mass, lerpSpeed);
        }
    }

    private void SetCollidersActive(bool isActive)
    {
        foreach(var collider in colliders)
        {
            if (!collider.isTrigger)
                collider.enabled = isActive;
        }
    }
}
