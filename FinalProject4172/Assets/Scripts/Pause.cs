using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	GameObject gameController;
	TextMesh status;

	public static bool paused = false;

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
			gameController.SendMessage ("pause");
			paused = false;
			status.text = "Pause";
		} 
		else {
			gameController.SendMessage ("pause");
			paused = true;
			status.text = "Play";
		}
		
	}
}
