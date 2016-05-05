using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject I;
	public GameObject L;
	public GameObject S;
	public GameObject T;
	public GameObject Square;
	public Material ghostMaterial;

	BrickControl brickControl;

	public GameObject youAreDone;

	public static float releaseTimer = 8f;
	public static float createTimer = releaseTimer + 2f;
	public static float time;


	bool hasBeenReleased = false;
	float startTime;

	public static GameObject activeBrick;
	public static GameObject ghostBrick;
	public static GameObject wand;
	public static GameObject wandTip;
	public static GameObject environment;
	public static GameObject ground;

	float timeElapsed = 0f;

	public static bool readyToCheck = false;

	// Use this for initialization
	void Start () {
		//set global refs
		wand = GameObject.Find ("Wand");
		wandTip = GameObject.Find ("WandTip");
		environment = GameObject.Find ("Environment");
		ground = GameObject.FindGameObjectsWithTag("Ground")[0];
		brickControl = gameObject.GetComponent<BrickControl> ();

		startTime = Time.time;
		createBrick();
	}

	void Update () {

		if (!Pause.paused && !Pause.targetLost) {
			float endTime = Time.time;
			time = endTime - startTime + timeElapsed;
			if (time > releaseTimer && time < createTimer) {				
				if (activeBrick != null) {
					activeBrick.tag = "Untagged";
				}
				if (!hasBeenReleased) {
					releaseBrick ();
					Debug.Log ("release");
				}
					
			} else if (time > createTimer) {
				if (hasBeenReleased) {
					createBrick ();
					Debug.Log ("create");
					startTime = Time.time;
					timeElapsed = 0f;
				} else {
					releaseBrick ();
				}
			}

			if (Input.GetKeyDown ("k")) { 
				createBrick ();
				Debug.Log ("create key down");
			}
			if (Input.GetKeyDown ("l")) { 
				releaseBrick ();
				Debug.Log ("create key down");
			}
		}
	}

	public void createBrick(){

		GameObject chosenPrefab = I;

		if (activeBrick != null) {
			activeBrick.tag = "Untagged";

		}
		hasBeenReleased = false;

		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
		GameObject n = null;
		if (number == 1) {
			n = Instantiate (I);
			chosenPrefab = I;

		} else if (number == 2) {
			n = Instantiate (L);
			chosenPrefab = L;

		} else if (number == 3) {
			n = Instantiate (S);
			chosenPrefab = S;

		} else if (number == 4) {
			n = Instantiate (T);
			chosenPrefab = T;

		} else if (number == 5) {
			n = Instantiate (Square);
			chosenPrefab = Square;

		}
		n.transform.parent = ground.transform;
		n.AddComponent <L_Shape>();

		n.tag = "active";
		activeBrick = n;
		ghostBrick = Instantiate(chosenPrefab);
		ghostBrick.transform.parent = ground.transform;
		ghostBrick.AddComponent <L_Shape>();

		foreach(Renderer rend in ghostBrick.GetComponentsInChildren<Renderer>()) {
			rend.material = ghostMaterial;
		}
		foreach(Collider col in ghostBrick.GetComponentsInChildren<Collider>()) {
			Destroy (col);
		}
		brickControl.initBrickPos ();
	}

	void releaseBrick() {
		if (activeBrick != null) {

			Rigidbody r = activeBrick.GetComponents<Rigidbody> () [0];
			r.useGravity = true;
			activeBrick.layer = 8; //ignoreselection layer instead of ignoreraycast
			foreach (Transform child in activeBrick.GetComponentsInChildren<Transform>()) {			
				child.gameObject.layer = 8;
			}
			hasBeenReleased = true;
			Destroy (ghostBrick);
			activeBrick = null;
			brickControl.releaseActiveBrick ();
		}
	}

	void mySelect(Touch touch){
		GameObject[] temp = GameObject.FindGameObjectsWithTag("active");
		if (temp.Length > 0) {
			activeBrick = temp [0];
			Rigidbody r = activeBrick.GetComponents<Rigidbody> ()[0];
			r.useGravity = true;
		}	
	}
		
	void pause(bool p){
		if (Pause.paused) {
			float endTime = Time.time;
			timeElapsed = endTime - startTime;
			Debug.Log ("pause");
		} else {			
			startTime = Time.time;
			Debug.Log ("play");
		}
	}

	public void gameOver() {

		Pause.paused = true;
		gameObject.SendMessage ("pause", true);
		youAreDone.SetActive (true);

		// reset timer/level
		GameController.releaseTimer = 8f; 
		LevelController.level = 0;
		LevelController.levelsCleared = 0;
		LevelController.totalLevelsCleared = 0;
		ControlInstructions.n = 0;

		Destroy (activeBrick);
		activeBrick = null;

		Destroy (ghostBrick);
		ghostBrick = null;

		SceneManager.LoadScene ("Menu");

	}

}
