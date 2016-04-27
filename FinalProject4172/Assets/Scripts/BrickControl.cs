using UnityEngine;
using System.Collections;

public class BrickControl : MonoBehaviour {

	GameObject activeBrick;
	GameObject wand, wandTip;
	Vector3[,] grid;
	int activeBrickGridX;
	int activeBrickGridZ;
	int manipulationMode;
	float endRotationPause;
	public GameObject tempGrid;



	//constants
	const int AXIS_X = 1;
	const int AXIS_Y = 2;
	const int AXIS_Z = 3;
	const int DIR_POS = 1;
	const int DIR_NEG = -1;
	const float ROTATION_DEGREES = 90f;
	const float TRANSLATION_VALUE = 2f;
	const float ROTATION_GESTURE_THRESHOLD = 15f;
	const float ROTATION_TOGGLE_THRESHOLD = 60f;
	const int GRID_SIZE = 5;
	const int ROTATION_MODE = 0;
	const int TRANSLATION_MODE = 1;
	const float ROTATION_PAUSE = 1f;

	// Use this for initialization
	Vector3 oldRot;
	GameObject env;
	GameObject ground;

	void Start () {
		GameObject temp = GameObject.Find("temp");
		if (temp != null) {
			activeBrick = temp;
		}

		endRotationPause = 0;
		manipulationMode = 0;
		activeBrickGridX = GRID_SIZE / 2;
		activeBrickGridZ = GRID_SIZE / 2;
		wand = GameController.wand;
		wandTip = GameController.wandTip;
		oldRot = wand.transform.eulerAngles;
		env = GameObject.Find ("Environment");
		ground = GameObject.Find ("Ground");
		Renderer envRenderer = env.transform.GetComponent<Renderer> ();

		float area = envRenderer.bounds.size.x * envRenderer.bounds.size.z;


		//groundRenderer.bounds.center;
		grid = new Vector3[GRID_SIZE, GRID_SIZE];
		float gridSquareCenterOffset = 1f / (float)GRID_SIZE / 2f;
		for (int i = 0; i < GRID_SIZE; i++) {
			for (int j = 0; j < GRID_SIZE; j++) {
				//Debug.Log (gridSquareCenterOffset);
				grid [i, j] = new Vector3(-0.5f + i * (1f / GRID_SIZE) + gridSquareCenterOffset, 0f, -0.5f + j * (1f / GRID_SIZE) + gridSquareCenterOffset);
			}
		}

		Vector3 gridPos = grid [activeBrickGridX, activeBrickGridZ];
		activeBrick.transform.localPosition = new Vector3(gridPos.x, activeBrick.transform.localPosition.y, gridPos.z);

		//Debug.Log (area);
	}
	
	// Update is called once per frame
	void Update () {

		//old rotation
		//Vector3 currRot = wand.transform.eulerAngles;
		//temp.transform.eulerAngles = new Vector3 (currRot.x - (currRot.x % 90), currRot.y - (currRot.y % 90), currRot.z - (currRot.z % 90));

		Vector3 currRot = wand.transform.eulerAngles;
		if ((currRot.x > 360 - ROTATION_TOGGLE_THRESHOLD || currRot.x < 0 + ROTATION_GESTURE_THRESHOLD) && (currRot.z > 360 - ROTATION_TOGGLE_THRESHOLD || currRot.z < 0 + ROTATION_TOGGLE_THRESHOLD)) {
			manipulationMode = ROTATION_MODE;
		} else {
			manipulationMode = TRANSLATION_MODE;
		}
		//Debug.Log (currRot.x);
		switch (manipulationMode) {
		case ROTATION_MODE:
		Debug.Log ("rotation mode");
			break;
		case TRANSLATION_MODE:
		Debug.Log ("translation mode");
			break;
		}


		if (manipulationMode == ROTATION_MODE && endRotationPause - Time.time <= 0) {
			float x = currRot.x - oldRot.x;
			float y = currRot.y - oldRot.y;
			float z = currRot.z - oldRot.z;
			if (x > 180)
				x -= 360;
			if (x < -180)
				x += 360;
			if (y > 180)
				y -= 360;
			if (y < -180)
				y += 360;
			if (z > 180)
				z -= 360;
			if (z < -180)
				z += 360;
			Vector3 diff = new Vector3 (x, y, z);
			//Debug.Log (diff);

			if (Mathf.Abs (diff.x) > ROTATION_GESTURE_THRESHOLD) {
				RotateBrick (AXIS_X, (int)Mathf.Sign (diff.x));
				//Debug.Log (wand.transform.eulerAngles + " - " + oldRot + " = " + diff);
			} else if (Mathf.Abs (diff.y) > ROTATION_GESTURE_THRESHOLD) {
				RotateBrick (AXIS_Y, (int)Mathf.Sign (diff.y));
				//Debug.Log (wand.transform.eulerAngles + " - " + oldRot + " = " + diff);

			} else if (Mathf.Abs (diff.z) > ROTATION_GESTURE_THRESHOLD) {
				RotateBrick (AXIS_Z, (int)Mathf.Sign (diff.z));
				//Debug.Log (wand.transform.eulerAngles + " - " + oldRot + " = " + diff);
			}


		}
	//translate
	else if (manipulationMode == TRANSLATION_MODE) {
			Vector3 currTrans = env.transform.InverseTransformPoint (wandTip.transform.position);
			float dist = 0;
			float minDist = float.MaxValue;
			int minI = 0;
			int minJ = 0;
			for (int i = 0; i < GRID_SIZE; i++) {
				for (int j = 0; j < GRID_SIZE; j++) {				
					dist = Vector3.Distance (currTrans, grid [i, j]);
					if (dist < minDist) {
						minDist = dist;
						minI = i;
						minJ = j;
					}	
				}
			}

			Vector3 gridPos = grid [minI, minJ];

			//check in bounds
			Vector3 translateDelta = env.transform.TransformPoint(gridPos - activeBrick.transform.localPosition);
			Bounds gb = ground.GetComponent<Renderer> ().bounds;
			Vector3 ngbMin = new Vector3 (gb.min.x, float.MinValue ,gb.min.z);
			Vector3 ngbMax = new Vector3 (gb.max.x, float.MaxValue ,gb.max.z);
			Bounds groundBounds = new Bounds ();
			groundBounds.SetMinMax (ngbMin, ngbMax);

			foreach (Transform c in activeBrick.GetComponentInChildren<Transform>()) {
				//if at least one brick out of bounds with this grid position abort
				if (!groundBounds.Contains (c.position + translateDelta)) {								
					return;				
				}				
			}
			//end of bounds check


			activeBrick.transform.localPosition = new Vector3 (gridPos.x, activeBrick.transform.localPosition.y, gridPos.z);
		}
		

		oldRot = wand.transform.eulerAngles;


		//translate/rotate with keyboard for debugging:
		//for direction: DIR_POS/DIR_NEG. AXIS_X/AXIS_Y/AXIS_Z for axes
		if (Input.GetKeyDown ("f")) { 
			RotateBrick (AXIS_X, DIR_POS);
		} else if (Input.GetKeyDown ("h")) {
			RotateBrick (AXIS_X, DIR_NEG);
		} else if (Input.GetKeyDown ("t")) {
			RotateBrick (AXIS_Z, DIR_POS);
		} else if (Input.GetKeyDown ("g")) {
			RotateBrick (AXIS_Z, DIR_NEG);
		} else if (Input.GetKeyDown ("v")) {
			RotateBrick (AXIS_Y, DIR_POS);
		} else if (Input.GetKeyDown ("b")) {
			RotateBrick (AXIS_Y, DIR_NEG);
		}

		//translation examples:
		if (Input.GetKeyDown ("d")) { 
			TranslateBrick (AXIS_X, DIR_POS);
		} else if (Input.GetKeyDown ("a")) {
			TranslateBrick (AXIS_X, DIR_NEG);
		} else if (Input.GetKeyDown ("w")) {
			TranslateBrick (AXIS_Z, DIR_POS);
		} else if (Input.GetKeyDown ("s")) {
			TranslateBrick (AXIS_Z, DIR_NEG);
		} else if (Input.GetKeyDown ("z")) {
			TranslateBrick (AXIS_Y, DIR_POS);
		} else if (Input.GetKeyDown ("x")) {
			TranslateBrick (AXIS_Y, DIR_NEG);
		}

		//debug grid positions (creates small cubes on grid):
		//need to add "temp" prefab to script's "tempGrid" public variable
		if (Input.GetKeyDown ("k")) {

			for (int i = 0; i < GRID_SIZE; i++) {
				for (int j = 0; j < GRID_SIZE; j++) {

					GameObject a = Instantiate (tempGrid);
					a.transform.parent = env.transform;
					a.transform.localPosition = grid [i, j];
					//Debug.Log ("a: " + grid [i, j]);

				}
			}
		}


	}

	void TranslateBrick(int axis, int dir) {

		Vector3 translateDelta = new Vector3 (0, 0, 0);

		switch (axis) {
		case AXIS_X:
			activeBrickGridX += dir;
			translateDelta.x += (float)dir * (1f / (float)GRID_SIZE);
			break;
		case AXIS_Z:
			activeBrickGridZ += dir;
			translateDelta.z += (float)dir * (1f / (float)GRID_SIZE);
			break;
		}
	
		if (activeBrickGridX < 0 || activeBrickGridX > GRID_SIZE - 1) {
			activeBrickGridX -= dir;
			return;
		}
		if (activeBrickGridZ < 0 || activeBrickGridZ > GRID_SIZE - 1) {
			activeBrickGridZ -= dir;
			return;
		}

		//translate delta to world space
		translateDelta = env.transform.TransformPoint (translateDelta);


		//create new bounding box to check brick in bounds
		Bounds gb = ground.GetComponent<Renderer> ().bounds;
		Vector3 ngbMin = new Vector3 (gb.min.x, float.MinValue ,gb.min.z);
		Vector3 ngbMax = new Vector3 (gb.max.x, float.MaxValue ,gb.max.z);
		Bounds groundBounds = new Bounds ();
		groundBounds.SetMinMax (ngbMin, ngbMax);

		foreach (Transform c in activeBrick.GetComponentInChildren<Transform>()) {						
			//at least one brick would be out of bounds with this translate, revert and abort
			if (!groundBounds.Contains (c.position + translateDelta)) {												
				switch (axis) {
				case AXIS_X:
					activeBrickGridX -= dir;
					break;
				case AXIS_Z:
					activeBrickGridZ -= dir;
					break;
				}
				return;
			}				
		}

		Vector3 gridPos = grid [activeBrickGridX, activeBrickGridZ];
		activeBrick.transform.localPosition = new Vector3(gridPos.x, activeBrick.transform.localPosition.y, gridPos.z);


	}

	void RotateBrick(int axis, int dir) {

		float angleInRad = Mathf.Deg2Rad * ROTATION_DEGREES;
		float cosTheta = dir * Mathf.Cos (angleInRad);
		float sinTheta = dir * Mathf.Sin (angleInRad);

		//Rigidbody rb = activeBrick.GetComponent<Rigidbody> ();
		float x = 0;//activeBrick.transform.eulerAngles.x;
		float y = 0;//activeBrick.transform.eulerAngles.y;
		float z = 0;//activeBrick.transform.eulerAngles.z;

		switch (axis) {
		case AXIS_X:
			x += dir * ROTATION_DEGREES;
			break;
		case AXIS_Y:
			y += dir * ROTATION_DEGREES;
			break;
		case AXIS_Z:
			z += dir * ROTATION_DEGREES;
			break;
		}
			
		//create new bounding box to check brick in bounds
		Bounds gb = ground.GetComponent<Renderer> ().bounds;
		Vector3 ngbMin = new Vector3 (gb.min.x, float.MinValue ,gb.min.z);
		Vector3 ngbMax = new Vector3 (gb.max.x, float.MaxValue ,gb.max.z);
		Bounds groundBounds = new Bounds ();
		groundBounds.SetMinMax (ngbMin, ngbMax);

		//create translates for individual cubes to test they will be in bounds
		Vector3 brickCenter = activeBrick.transform.position;
		foreach (Transform c in activeBrick.GetComponentInChildren<Transform>()) {
			Vector3 diff = c.position - brickCenter;
			float rx = c.position.x;
			float ry = c.position.y;
			float rz = c.position.z;
			switch (axis) {
			case AXIS_X:
				ry = cosTheta * diff.y - sinTheta * diff.z + brickCenter.y;
				rz = sinTheta * diff.y - cosTheta * diff.z + brickCenter.z;
				break;
			case AXIS_Y:
				rz = cosTheta * diff.z - sinTheta * diff.x + brickCenter.z;
				rx = sinTheta * diff.z - cosTheta * diff.x + brickCenter.x;
				break;
			case AXIS_Z:				
				rx = cosTheta * diff.x - sinTheta * diff.y + brickCenter.x;
				ry = sinTheta * diff.x - cosTheta * diff.y + brickCenter.y;
				break;

			}
			Vector3 newChildPosition = new Vector3(rx,ry,rz);
			if(!groundBounds.Contains(newChildPosition)) {	
				//if at least one cube is out of bounds the rotation is aborted

				return;
			}

		}




		//activeBrick.transform.eulerAngles = new Vector3(x,y,z);
		activeBrick.transform.Rotate(x,y,z, Space.World);



		endRotationPause = Time.time + ROTATION_PAUSE;

	}
}
