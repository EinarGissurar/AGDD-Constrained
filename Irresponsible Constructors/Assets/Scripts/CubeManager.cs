using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ConstructorControllerAddedAction(ConstructorController controller);
public delegate void ConstructorControllerDeletedAction();

public delegate void CubeReturnPoint();
public delegate void CubeLostPoint();

public delegate void CubeReturned();

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
	bool isExited = false;
	bool isOnGoal = false;

	public event CubeReturnPoint CubeReturnPointEvent;
	public event CubeLostPoint CubeLostPointEvent;
    public event ConstructorControllerAddedAction ConstructorControllerAddedEvent;
    public event ConstructorControllerDeletedAction ConstructorControllerDeletedEvent;
	public static event CubeReturned onCubeReturned;

	public static List<int> cubesReturned = new List<int>();
	public static List<int> cubesLost = new List<int>();

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
    }

    private void RemoveRigidBody()
    {
        if (rigidBody != null)
            Destroy(rigidBody);
    }

    private void OnGrab()
    {
        constructorController.BreakEvent -= OnDrop;
        Destroy(constructorController);

        if (ConstructorControllerDeletedEvent != null) 
            ConstructorControllerDeletedEvent();
    }

    private void OnDrop()
    {
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        SetCollidersActive(true);

        if(constructorController != null)
        {
            Destroy(constructorController);

            if (ConstructorControllerDeletedEvent != null)
                ConstructorControllerDeletedEvent();
        }
    }

	private void OnBreak()
	{
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
		SetCollidersActive(true);

		if(constructorController != null)
		{
			Destroy(constructorController);

			if (ConstructorControllerDeletedEvent != null)
				ConstructorControllerDeletedEvent();
		}

		Destroy (this);
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
            constructorController.BreakEvent += OnBreak;
            constructorController.FloorController = floorController;
            constructorController.CalculatePositionLerpValue();
            constructorController.SetSettings(floorOffset, dotThresholdBreak, grabableScript.Mass, lerpSpeed);

            if (ConstructorControllerAddedEvent != null)
                ConstructorControllerAddedEvent(constructorController);
        }

		Debug.Log ("onCubeReturned: " + onCubeReturned);
		if (collision.gameObject.name == "ConveyorBeltGoal" && onCubeReturned != null  && !isOnGoal) {
			isOnGoal = true;
			//Debug.Log ("hit conveyor belt goal");

			cubesReturned.Add (collision.gameObject.GetInstanceID ());
			onCubeReturned ();
				//score++;
			ScoreManager.newScore += 1;
			//Debug.Log (" Entered conveyor");
			CubeReturnPoint ();
		}
		//Debug.Log (collision.gameObject.name);
    }

	void OnTriggerEnter2D(Collider2D collision) {
		if (isExited)
			return;
		
		if (collision.name == "SceneExitBottom" && onCubeReturned != null) {
			ScoreManager.newScore -= 1;

			onCubeReturned ();
			CubeLostPoint ();
			isExited = true;
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
	//má henda?
	private void OnBecameInvisible()
	{

		//lose game?

		/*if (!cubesReturned.Contains (this.gameObject.GetInstanceID ())) {
			//Debug.Log ("Box fell down, player should lose");
			ScoreManager.newScore -= 1;
			Debug.Log ("calling cube lost point");
			CubeLostPoint ();
		} 
		else {//for debugging purposes, can be removed
			//Debug.Log ("Box returned normally");
		}
		Destroy(this.gameObject);*/
	}

	void CubeReturnPoint() {
		if (CubeReturnPointEvent != null) {
			//Debug.Log (this.gameObject.transform.position);
			CubeReturnPointEvent();
		}

	}

	void CubeLostPoint() {
		if (CubeLostPointEvent != null) {
			//Debug.Log ("cube lost point event");
			CubeLostPointEvent();
		}
	}
}
