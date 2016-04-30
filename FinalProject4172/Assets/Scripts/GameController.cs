using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public GameObject I;
	public GameObject L;
	public GameObject S;
	public GameObject T;
	public GameObject Square;
	BrickControl brickControl;

	public static float timer = 10f;
	public static float showTimer;

	float startTime;

	public static GameObject activeBrick;
	public static GameObject wand;
	public static GameObject wandTip;
	public static GameObject environment;
	public static GameObject ground;

	// Use this for initialization
	void Start () {
		//set global refs
		wand = GameObject.Find ("Wand");
		wandTip = GameObject.Find ("WandTip");
		environment = GameObject.Find ("Environment");
		ground = GameObject.Find ("Ground");
		brickControl = gameObject.GetComponent<BrickControl> ();

		startTime = Time.time;
		createBrick();

		showTimer = timer;

	}

	// Update is called once per frame
	void Update () {
		
		float endTime = Time.time;
		float time = endTime - startTime;
		if (time > timer) {
			if (time % 1 == 0) {
				showTimer -= time;
			}

			if (activeBrick != null) {
				activeBrick.tag = "Untagged";
			}

			createBrick ();
			Rigidbody r = activeBrick.GetComponents<Rigidbody> ()[0];
			r.useGravity = true;
			startTime = Time.time;
		}

	}

	public void createBrick(){

		if (activeBrick != null) {
			activeBrick.tag = "Untagged";
		}

		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
		//int number = 2;
		GameObject n = null;
		if (number == 1) {
			n = Instantiate (I);

		} else if (number == 2) {
			n = Instantiate (L);

		} else if (number == 3) {
			n = Instantiate (S);

		} else if (number == 4) {
			n = Instantiate (T);

		} else if (number == 5) {
			n = Instantiate (Square);

		}
		n.transform.parent = environment.transform;
		n.AddComponent <L_Shape>();



		n.tag = "active";
		activeBrick = n;
		brickControl.initBrickPos ();
	}


	void mySelect(Touch touch){
		GameObject[] temp = GameObject.FindGameObjectsWithTag("active");
		if (temp.Length > 0) {
			activeBrick = temp [0];
			Rigidbody r = activeBrick.GetComponents<Rigidbody> ()[0];
			r.useGravity = true;
		}

		createBrick ();
		
	}

	private void OnEnable()
	{
		UserInputHandler.OnTap += mySelect;
	}

	private void OnDisable()
	{
		UserInputHandler.OnTap -= mySelect;
	}

}
