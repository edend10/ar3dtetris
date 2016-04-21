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

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createBrick(){
		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
		GameObject newObject;
		if (number == 1) {
			newObject = Instantiate (I);
		}


	}
}
