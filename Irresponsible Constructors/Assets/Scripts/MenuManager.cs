using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

	[SerializeField]
	private EventSystem eventSystem;

	[SerializeField]
	Button[] menuButtons;

	int selectedIndex;

	// Use this for initialization
	void Start () {
		SetSelectedIndex (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			menuButtons [selectedIndex].onClick.Invoke ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			DecrementIndex ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			IncrementIndex ();
		}
	}

	private void IncrementIndex() {
		selectedIndex = selectedIndex + 1 < menuButtons.Length ? selectedIndex + 1 : 0;
		SetSelectedIndex (selectedIndex);
	}

	private void DecrementIndex() {
		selectedIndex = selectedIndex - 1 >= 0 ? selectedIndex - 1 : menuButtons.Length - 1;
		SetSelectedIndex (selectedIndex);
	}

	private void SetSelectedIndex(int index) {
		selectedIndex = index;
		eventSystem.SetSelectedGameObject (menuButtons[index].gameObject);
	}

	public void Play() {
		SceneManager.LoadScene ("Main");
	}

	public void Quit() {
		Application.Quit ();
	}
}
