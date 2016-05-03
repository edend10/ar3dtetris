using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public GameObject I;
	public GameObject L;
	public GameObject S;
	public GameObject T;
	public GameObject Square;
	public Material ghostMaterial;

	BrickControl brickControl;


	public static float releaseTimer = 10f;
	public static float createTimer = releaseTimer + 2f;
	public static float showTimer;


	float startTime;

	public static GameObject activeBrick;
	public static GameObject ghostBrick;
	public static GameObject wand;
	public static GameObject wandTip;
	public static GameObject environment;
	public static GameObject ground;

	bool paused = false;
	float timeElapsed = 0f;

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

		showTimer = releaseTimer;

	}

	// Update is called once per frame
	void Update () {

		if (!paused) {
			float endTime = Time.time;
			float time = endTime - startTime + timeElapsed;
			if (time > releaseTimer && time < createTimer) {				
				if (time % 1 == 0) {
					showTimer -= time;
				}

				if (activeBrick != null) {
					activeBrick.tag = "Untagged";
				}
				
				releaseBrick ();

			} else if (time > createTimer) {
				createBrick ();
				startTime = Time.time;
				timeElapsed = 0f;
			}

			if (Input.GetKeyDown ("k")) { 
				createBrick ();
			}
			if (Input.GetKeyDown ("l")) { 
				releaseBrick ();
			}
		}

	}

	public void createBrick(){

		GameObject chosenPrefab = I;

		if (activeBrick != null) {
			activeBrick.tag = "Untagged";
		}

		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
		//int number = 2;
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

	private void OnEnable()
	{
		UserInputHandler.OnTap += mySelect;
	}

	private void OnDisable()
	{
		UserInputHandler.OnTap -= mySelect;
	}

	void pause(bool p){
		paused = p;
		if (paused) {
			float endTime = Time.time;
			timeElapsed = endTime - startTime;
		} else {			
			startTime = Time.time;
		}
	}

}
