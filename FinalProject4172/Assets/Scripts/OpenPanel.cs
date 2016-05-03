using UnityEngine;
using System.Collections;

public class OpenPanel : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void youAreSelected(){
		GameObject control = GameObject.Find ("GameController");

		if (panel.activeSelf) {
			panel.SetActive (false);
			control.SendMessage ("pause", false);
		} else {
			panel.SetActive (true);
			control.SendMessage ("pause", true);
		}
	}
}
