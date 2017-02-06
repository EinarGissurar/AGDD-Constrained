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


    bool isLeft = false;
    bool isRight = false;

    // Use this for initialization
    void Start () {
		
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
            spriteRenderer.flipX = isLeft;
    }
}
