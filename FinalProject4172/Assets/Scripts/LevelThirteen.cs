using UnityEngine;
using System.Collections;

public class LevelThirteen : MonoBehaviour {

	GameObject g;

	float timeIn, timeOut, timeStay;

	void Start() {

	}

	void Update() {
		if (timeStay - timeIn > 2f) {
			Debug.Log ("GAME OVER");
			g.GetComponent<GameController> ().gameOver ();
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
