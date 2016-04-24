using UnityEngine;
using System.Collections;

public class BrickControl : MonoBehaviour {

	GameObject activeBrick;

	//constants
	const int AXIS_X = 1;
	const int AXIS_Y = 2;
	const int AXIS_Z = 3;
	const int DIR_POS = 1;
	const int DIR_NEG = -1;
	const float ROTATION_DEGREES = 90f;
	const float TRANSLATION_VALUE = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject temp = GameObject.Find("temp");
		//GameObject[] temp = GameObject.FindGameObjectsWithTag("active");
		//activeBrick = GameController.activeBrick;
		//if(activeBrick != null) {
		if (temp != null) {
			activeBrick = temp;

			//rotation examples:
			//for direction: DIR_POS/DIR_NEG. AXIS_X/AXIS_Y/AXIS_Z for axes
			if (Input.GetKeyDown ("q")) { 
				RotateBrick (AXIS_X, DIR_POS);
			} else if (Input.GetKeyDown ("a")) {
				RotateBrick (AXIS_X, DIR_NEG);
			} else if (Input.GetKeyDown ("w")) {
				RotateBrick (AXIS_Y, DIR_POS);
			} else if (Input.GetKeyDown ("s")) {
				RotateBrick (AXIS_Y, DIR_NEG);
			} else if (Input.GetKeyDown ("e")) {
				RotateBrick (AXIS_Z, DIR_POS);
			} else if (Input.GetKeyDown ("d")) {
				RotateBrick (AXIS_Z, DIR_NEG);
			}

			//translation examples:
			if (Input.GetKeyDown ("r")) { 
				TranslateBrick (AXIS_X, DIR_POS);
			} else if (Input.GetKeyDown ("f")) {
				TranslateBrick (AXIS_X, DIR_NEG);
			} else if (Input.GetKeyDown ("t")) {
				TranslateBrick (AXIS_Y, DIR_POS);
			} else if (Input.GetKeyDown ("g")) {
				TranslateBrick (AXIS_Y, DIR_NEG);
			} else if (Input.GetKeyDown ("y")) {
				TranslateBrick (AXIS_Z, DIR_POS);
			} else if (Input.GetKeyDown ("h")) {
				TranslateBrick (AXIS_Z, DIR_NEG);
			}
		}
	}

	void TranslateBrick(int axis, int dir) {
		float x = 0;
		float y = 0;
		float z = 0;
		switch (axis) {
		case AXIS_X:
			x = dir * TRANSLATION_VALUE;
			break;
		case AXIS_Y:
			y = dir * TRANSLATION_VALUE;
			break;
		case AXIS_Z:
			z = dir * TRANSLATION_VALUE;
			break;
		}

		activeBrick.transform.Translate (x, y, z);
	}

	void RotateBrick(int axis, int dir) {
		float x = 0;
		float y = 0;
		float z = 0;
		switch (axis) {
		case AXIS_X:
			x = dir * ROTATION_DEGREES;
			break;
		case AXIS_Y:
			y = dir * ROTATION_DEGREES;
			break;
		case AXIS_Z:
			z = dir * ROTATION_DEGREES;
			break;
		}
			
		activeBrick.transform.Rotate (x, y, z);
	}
}
