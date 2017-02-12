using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    private KeyCode right;

    [SerializeField]
    private KeyCode left;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    ConstructorController constructorController;

	[SerializeField]
	Transform grabTransform;
	float originalGrabTransformPositionX;

    bool isLeft = false;
    bool isRight = false;

    public bool IsRight { get { return !spriteRenderer.flipX; } }

    // Use this for initialization
    void Start () {
		originalGrabTransformPositionX = grabTransform.localPosition.x;
		Debug.Log (originalGrabTransformPositionX);
	}
	
	// Update is called once per frame
	void Update () {
        bool isInput = Input.GetKey(left) || Input.GetKey(right);
        isLeft = Input.GetKey(left);
        isRight = Input.GetKey(right);

        if (isLeft)
        {
            constructorController.GoLeft();
        }
        else if (isRight)
        {
            constructorController.GoRight();
        }

        if (isInput)
        {
            spriteRenderer.flipX = isLeft;
			float x = isLeft ? -originalGrabTransformPositionX : originalGrabTransformPositionX;
			grabTransform.localPosition = new Vector3 (x, grabTransform.localPosition.y, grabTransform.localPosition.z);
        }
    }
}
