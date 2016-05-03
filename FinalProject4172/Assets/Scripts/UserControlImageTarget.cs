using UnityEngine;
using System.Collections;

public class UserControlImageTarget : MonoBehaviour {

	public GameObject head;
	public GameObject boardTarget;
	public GameObject board;
	GameObject travelTarget;

	Vector3 oldTravelTargetPosition;
	Vector3 oldTravelTargetRotation;

	// Use this for initialization
	void Start () {
		travelTarget = gameObject;
		oldTravelTargetPosition = travelTarget.transform.position;
		oldTravelTargetRotation = travelTarget.transform.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 travelTargetPosition = travelTarget.transform.position;
		Vector3 boardTargetPosition = boardTarget.transform.position;
		Vector3 boardPosition = board.transform.position;
		Vector3 headPosition = head.transform.position;

		float travelTargetTransZDiff = (travelTargetPosition - oldTravelTargetPosition).z;

		board.transform.Translate (0,0,travelTargetTransZDiff);
		//Debug.Log ("AutomnTarget: " + travelTargetPosition + " | StonesTarget: " + boardTarget);
		oldTravelTargetPosition = travelTargetPosition;


		//rotation
		Vector3 travelTargetRotation = travelTarget.transform.eulerAngles;

		float travelTartgetRotYDiff = (travelTargetRotation - oldTravelTargetRotation).y;
		board.transform.Rotate (new Vector3(0,travelTartgetRotYDiff,0));


		oldTravelTargetRotation = travelTargetRotation;
	}
}
