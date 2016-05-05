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
			gameController.SendMessage ("pause",false);
			paused = false;
			status.text = "Pause";
		} 
		else {
			gameController.SendMessage ("pause", true);
			paused = true;
			status.text = "Play";
		}
		
	}
}
