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
		
		if (status.text == "Pause") {
		}
		gameController.SendMessage ("pause", true);
		
	}
}
