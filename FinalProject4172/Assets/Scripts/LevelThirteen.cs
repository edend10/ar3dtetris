using UnityEngine;
using System.Collections;

public class LevelThirteen : MonoBehaviour {

	GameObject g;

	float timeIn, timeOut, timeStay;

	void Update() {
		if (timeStay - timeIn > 1f) {
			Debug.Log ("GAME OVER");
			GameObject GC = GameObject.Find ("GameController");
			GC.SendMessage ("gameOver");
		}
	}

	void OnTriggerEnter (Collider block) {
		timeIn = Time.time;
	}
	void OnTriggerExit (Collider block) {
		timeOut = Time.time;
	}
	void OnTriggerStay (Collider block) {
		timeStay = Time.time;
	}
}
