using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	public GameObject head;
	public GameObject board;

	public GameObject boardTarget;

	public int marker;


	float fixedDistance = 2.5f;
	Vector3 oldAngle;
	float multiplier = 0.2f;
	float THRESHOLD = 5f;

	// Use this for initialization
	void Start () {
		oldAngle = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetPosition = gameObject.transform.position;
		Vector3 headPosition = head.transform.position;
		Vector3 boardPosition = board.transform.position;
		Vector3 boardTargetPosition = boardTarget.transform.position;


			/*
		//translation
		float displacement = targetPosition.z - boardTargetPosition.z + fixedDistance;
		Vector3 move = new Vector3 (boardPosition.x, boardPosition.y, 2 * displacement);
		board.transform.position = move;
		*/

		/*

		//Translation
		fixedDistance = Mathf.Abs(boardTargetPosition.z - headPosition.z);

		float z = Mathf.Abs(targetPosition.z - headPosition.z);

		float displacement = z - fixedDistance;
		Vector3 move = new Vector3 (boardPosition.x, boardPosition.y, displacement);
		board.transform.position = move;
		*/

		//Rotation
		if (marker == 1) {
			Quaternion q = gameObject.transform.rotation;
			board.transform.rotation = q;
		}
		if (marker == 2) {
			Vector3 newAngle = transform.eulerAngles;
			Vector3 angleDiff = newAngle - oldAngle;
			if(Mathf.Abs(angleDiff.y) > THRESHOLD) {
				int dir = (int)Mathf.Sign (angleDiff.y);

				board.transform.Translate(new Vector3 (0,0,dir * multiplier));
				oldAngle = newAngle;
			}

		}
	}
}
