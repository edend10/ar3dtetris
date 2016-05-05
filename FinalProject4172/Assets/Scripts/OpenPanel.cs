﻿using UnityEngine;
using System.Collections;

public class OpenPanel : MonoBehaviour {

	public GameObject panel;

	public void youAreSelected(){
		GameObject control = GameObject.Find ("GameController");

		if (panel.activeSelf) {
			panel.SetActive (false);
			Pause.paused = false;
			control.SendMessage ("pause", false);
		} else {
			panel.SetActive (true);
			Pause.paused = true;
			control.SendMessage ("pause", true);
		}
	}
}
