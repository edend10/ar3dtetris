using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public GameObject I;
	public GameObject L;
	public GameObject S;
	public GameObject T;
	public GameObject Square;

	public GameObject ground;

	float startTime;

	public static GameObject activeBrick;

	// Use this for initialization
	void Start () {
		//startTime = Time.time;
		createBrick();
		Debug.Log ("test");

	}
	
	// Update is called once per frame
	void Update () {
		/*
		float endTime = Time.time;
		float time = endTime - startTime;
		if (time > 7) {
			if (activeBrick != null) {
				activeBrick.tag = "Untagged";
			}
			createBrick ();
			startTime = Time.time;

		}
		*/
	}

	public void createBrick(){
		Debug.Log ("create brick");
		if (activeBrick != null) {
			activeBrick.tag = "Untagged";
		}

		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
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
		n.transform.parent = ground.transform;
		n.AddComponent <L_Shape>();

		n.tag = "active";
		activeBrick = n;
	}

	private void OnEnable()
	{
		DropBrickVirtualButtonEventHandler.drop += createBrick;
	}

	private void OnDisable()
	{
		DropBrickVirtualButtonEventHandler.drop -= createBrick;
	}
}
