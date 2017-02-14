using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField]
    Transform startPoint;

    [SerializeField]
    Transform endPoint;

	[SerializeField]
	Rigidbody2D rb;

    public Vector2 RightDirection { get { return (Vector2)(endPoint.position - startPoint.position).normalized; } }
    public Vector2 LeftDirection { get { return (Vector2)(startPoint.position - endPoint.position).normalized; } }

    public Vector2 Normal { get { return new Vector2(-RightDirection.y, RightDirection.x).normalized; } }

    public Vector2 StartPosition { get { return startPoint.position; } }

    public Vector2 EndPosition { get { return endPoint.position; } }

	GameManager gamemanger;

	void Awake() {
		gamemanger = FindObjectOfType<GameManager> ();
		Debug.Log ("ConveyorLayer: " + LayerMask.NameToLayer ("Conveyor"));
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer ("Conveyor"), gameObject.layer);
	}

    // Use this for initialization
    void Start()
    {

    }

	void OnEnable() {
		gamemanger.TimeOutEvent += OnTimeOut;
	}

	void OnDisable() {
		gamemanger.TimeOutEvent -= OnTimeOut;
	}

    // Update is called once per frame
    void Update()
    {
		
		if (Vector2.Dot(RightDirection, Vector2.right) <= 0.4)
		{
			Destroy (this);
			rb.constraints = RigidbodyConstraints2D.None;
		}
    }

    public Vector2 GetPositionOnFloor(float lerpValue)
    {
        return Vector2.Lerp(StartPosition, EndPosition, lerpValue);
    }

	private void OnTimeOut() {
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
	}
}
