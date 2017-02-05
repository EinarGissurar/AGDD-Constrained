using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorController : MonoBehaviour {

    [SerializeField]
    FloorController floorController;

    [SerializeField]
    private KeyCode right;

    [SerializeField]
    private KeyCode left;

    [SerializeField]
    float speed = 2;

    [SerializeField]
    float mass = 1;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float characterOffset;

    [SerializeField]
    float dotThresholdBreak;

    [SerializeField]
    float forceMagnitudeAppliedToFloor = 9.8f;

    [SerializeField]
    float m_mass = 1f;

    public float Mass { get { return m_mass; } set { m_mass = value; } }

    bool isLeft = false;
    bool isRight = false;

    float positionLerpValue;

    Rigidbody2D rigidBody;
    Collider2D[] colliders;

    void Awake()
    {
        colliders = GetComponents<Collider2D>();
        CalculatePositionLerpValue();
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (floorController != null)
        {
            bool isInput = Input.GetKey(left) || Input.GetKey(right);
            isLeft = Input.GetKey(left);
            isRight = Input.GetKey(right) ^ isLeft;

            if (isInput)
                spriteRenderer.flipX = isLeft;

            if (isLeft)
                positionLerpValue = Mathf.Clamp01(positionLerpValue - 0.1f * Time.deltaTime);
            else if (isRight)
                positionLerpValue = Mathf.Clamp01(positionLerpValue + 0.1f * Time.deltaTime);

            transform.position = floorController.GetPositionOnFloor(positionLerpValue) + floorController.Normal * characterOffset;

            if (Vector2.Dot(floorController.RightDirection, Vector2.right) <= dotThresholdBreak)
                floorController = null;
        }
        else if(rigidBody == null)
        {
            rigidBody = gameObject.AddComponent<Rigidbody2D>();
            foreach (var collider in colliders)
                collider.enabled = true;
        }
    }

    public void FixedUpdate()
    {
        if(floorController != null)
            floorController.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(-floorController.Normal * forceMagnitudeAppliedToFloor * Mass, transform.position);
    }

    private void CalculatePositionLerpValue()
    {
        positionLerpValue = (transform.position.x - floorController.StartPosition.x) / (floorController.EndPosition.x - floorController.StartPosition.x);
    }
}
