using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	GameObject gameController;
	TextMesh status;

	bool paused = false;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectsWithTag("GameController")[0];
		status = GameObject.Find("Pause").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void youAreSelected(){
		
		if (paused) {
			gameController.SendMessage ("pause", false);
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
