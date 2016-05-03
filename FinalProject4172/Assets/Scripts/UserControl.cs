using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	public GameObject head;
	public GameObject board;

	public GameObject boardTarget;

	float fixedDistance = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetPosition = gameObject.transform.position;
		Vector3 headPosition = head.transform.position;
		Vector3 boardPosition = board.transform.position;
		Vector3 boardTargetPosition = boardTarget.transform.position;
		Vector3 fixedVector = boardTargetPosition - headPosition;


		//translation
		float displacement = targetPosition.z - boardTargetPosition.z - fixedDistance;
		Vector3 move = new Vector3 (boardPosition.x, boardPosition.y, 2 * displacement);
		board.transform.position = move;

		//scaling

		float scaleFactor = targetPosition.x - boardTargetPosition.x;

		//board.transform.localScale = new Vector3(scaleFactor, 0, 0);

		/*

		//Translation
		fixedDistance = Mathf.Abs(boardTargetPosition.z - headPosition.z);

		float z = Mathf.Abs(targetPosition.z - headPosition.z);

		float displacement = z - fixedDistance;
		Vector3 move = new Vector3 (boardPosition.x, boardPosition.y, displacement);
		board.transform.position = move;
		*/

		//Rotation

		Quaternion q = gameObject.transform.rotation;
		board.transform.rotation = q;
	
	}
}
