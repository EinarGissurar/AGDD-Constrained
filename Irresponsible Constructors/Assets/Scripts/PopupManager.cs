using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {

    public Animator anim;
	public Transform cube;
    public RectTransform oneUp;
    public RectTransform oneDown;
	public CubeManager cubemanager;

	// Use this for initialization
	void Start () {
		cubemanager = this.GetComponentInParent<CubeManager> ();
		OnEnable ();
		//Debug.Log (cubemanager);
	}
	
	// Update is called once per frame
	void Update () {
		oneUp.position = new Vector3(oneUp.position.x, oneUp.position.y + 1.0f, oneUp.position.z);
		oneDown.position = new Vector3(oneDown.position.x, oneDown.position.y + 1.0f, oneDown.position.z);
    }

	void OnEnable() 
	{
		if (cubemanager != null) {
			//Debug.Log ("event enabled!!");
			cubemanager.CubeReturnPointEvent += OnReturn;
			cubemanager.CubeLostPointEvent += OnLost;
		}
	}

	void OnDisable() 
	{
		if (cubemanager != null) {
			cubemanager.CubeReturnPointEvent -= OnReturn;
			cubemanager.CubeLostPointEvent -= OnLost;
		}
	}


	public void OnLost()
	{
		Debug.Log (cube.position);

		oneDown.position = Camera.main.WorldToScreenPoint(new Vector3(cube.position.x,cube.position.y+2.5f,cube.position.z));
		Debug.Log (oneDown.position);
		anim.SetTrigger("OneDown");
	}

	public void OnReturn(){
		oneUp.position = Camera.main.WorldToScreenPoint(new Vector3(cube.position.x,cube.position.y+0.5f,cube.position.z));
		Debug.Log (oneUp.position);
		anim.SetTrigger("OneUp");
	}
}
