using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {

    public Animator anim;
    public RectTransform oneUp;
    public RectTransform oneDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            oneUp.position = Input.mousePosition;
            anim.SetTrigger("OneUp");
        }

        if (Input.GetMouseButtonDown(1)) {
            oneDown.position = Input.mousePosition;
            anim.SetTrigger("OneDown");
        }
    }
}
