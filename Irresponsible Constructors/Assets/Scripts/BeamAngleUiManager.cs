using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamAngleUiManager : MonoBehaviour {

	[SerializeField]
	private Text leftAngle;

	[SerializeField]
	private Text rightAngle;

	[SerializeField]
	private Color negativeColor;

	[SerializeField]
	private Color positiveColor;

	[SerializeField]
	private Color neutralColor;

	[SerializeField]
	private FloorController floorController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float leftAngle = Mathf.Floor(Vector2.Angle (floorController.LeftDirection, Vector2.left)); 
		float rightAngle = Mathf.Floor(Vector2.Angle (floorController.RightDirection, Vector2.right));
		this.leftAngle.text = floorController.LeftDirection.y < 0 && leftAngle != 0 ? "-" : "";
		this.rightAngle.text = floorController.RightDirection.y < 0 && rightAngle != 0 ? "-" : "";
		this.leftAngle.text += leftAngle.ToString () + "˚";
		this.rightAngle.text += rightAngle.ToString () + "˚";

		this.leftAngle.color = Color.blue;
		this.rightAngle.color = Color.blue;

		if ((int)leftAngle != 0)
			this.leftAngle.color = floorController.LeftDirection.y < 0 ? Color.red : Color.green;
		if ((int)rightAngle != 0)
			this.rightAngle.color = floorController.RightDirection.y < 0 ? Color.red : Color.green;
	}
}
