using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private KeyCode right;

    [SerializeField]
    private KeyCode left;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    private bool isLeft = false;
    private bool isRight = false;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        bool isInput = Input.GetKey(left) || Input.GetKey(right);
        isLeft = Input.GetKey(left);
        isRight = Input.GetKey(right) ^ isLeft;

        if (isInput)
            spriteRenderer.flipX = isLeft;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (rb.velocity.magnitude > maxSpeed)
            return;

		if(isLeft)
        {
            rb.AddForce(new Vector2(-1, 0) * 10);
        }
        else if(isRight)
        {
            rb.AddForce(new Vector2(1, 0) * 10);
        }
	}
}
