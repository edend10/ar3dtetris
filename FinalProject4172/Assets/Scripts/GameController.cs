﻿using UnityEngine;
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

	public GameObject activeBrick;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

		float endTime = Time.time;
		float time = endTime - startTime;
		if (time > 5) {
			createBrick ();
			startTime = Time.time;
		}
	}

	public void createBrick(){
		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
		GameObject n;
		if (number == 1) {
			n = Instantiate (I);
			n.transform.parent = ground.transform;
			n.AddComponent <L_Shape>();
		} else if (number == 2) {
			n = Instantiate (L);
			n.transform.parent = ground.transform;
			n.AddComponent <L_Shape>();
		} else if (number == 3) {
			n = Instantiate (S);
			n.transform.parent = ground.transform;
			n.AddComponent <L_Shape>();
		} else if (number == 4) {
			n = Instantiate (T);
			n.transform.parent = ground.transform;
			n.AddComponent <L_Shape>();
		} else if (number == 5) {
			n = Instantiate (Square);
			n.transform.parent = ground.transform;
			n.AddComponent <L_Shape>();
		}
	}
}
