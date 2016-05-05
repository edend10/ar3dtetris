using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	GameObject gameController;
	TextMesh status;

	public static bool paused = true;
	public static bool targetLost = true;

	void Start () {
		gameController = GameObject.FindGameObjectsWithTag("GameController")[0];
		status = GameObject.Find("Pause").GetComponent<TextMesh> ();
		paused = false;
		targetLost = false;
	}

	public void youAreSelected(){
		
		if (paused) {
			paused = false;
			gameController.SendMessage ("pause",false);
			status.text = "Pause";
		} 
		else {
			paused = true;
			gameController.SendMessage ("pause", true);
			status.text = "Play";
		}
		
	}
}
