using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BreakAction();

public class ConstructorController : MonoBehaviour {

    [SerializeField]
    FloorController floorController;
    public FloorController FloorController { get { return floorController; } set { floorController = value; } }

    [SerializeField]
    float floorOffset;

    [SerializeField]
    float dotThresholdBreak;

    [SerializeField]
    float forceMagnitudeAppliedToFloor = 9.8f;

    [SerializeField]
    float m_mass = 1f;

    [SerializeField]
    float lerpSpeed = 0.1f;

    [SerializeField]
    bool calculateLerpOnAwake = false;

    public float Mass { get { return m_mass; } set { m_mass = value; } }

    public event BreakAction BreakEvent;

    float positionLerpValue;

	GameManager gameManager;

    void Awake()
    {
        if (calculateLerpOnAwake)
            CalculatePositionLerpValue();

		gameManager = FindObjectOfType<GameManager> ();
    }

	void OnEnable() {
		gameManager.TimeOutEvent += OnTimeOut;
	}

	void onDisable() {
		gameManager.TimeOutEvent -= OnTimeOut;
	}

	void OnDestroy() {
		gameManager.TimeOutEvent -= OnTimeOut;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (floorController != null)
        {
            transform.position = floorController.GetPositionOnFloor(positionLerpValue) + floorController.Normal * floorOffset;

            if (Vector2.Dot(floorController.RightDirection, Vector2.right) <= dotThresholdBreak)
            {
                floorController = null;

                if (BreakEvent != null)
                    BreakEvent();
            }
        }
    }

    public void GoLeft()
    {
        positionLerpValue = Mathf.Clamp01(positionLerpValue - lerpSpeed * Time.deltaTime);
    }

    public void GoRight()
    {
        positionLerpValue = Mathf.Clamp01(positionLerpValue + lerpSpeed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        if(floorController != null)
            floorController.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Physics2D.gravity * Mass, transform.position, ForceMode2D.Force);
    }

    public void CalculatePositionLerpValue()
    {
        positionLerpValue = (transform.position.x - floorController.StartPosition.x) / (floorController.EndPosition.x - floorController.StartPosition.x);
    }

    public void SetSettings(float floorOffset, float dotThresholdBreak, float mass, float lerpSpeed)
    {
        this.floorOffset = floorOffset;
        this.dotThresholdBreak = dotThresholdBreak;
        m_mass = mass;
        this.lerpSpeed = lerpSpeed;
    }

	public void OnTimeOut() {
		enabled = false;
	}
}
