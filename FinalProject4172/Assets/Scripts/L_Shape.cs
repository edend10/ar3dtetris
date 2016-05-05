using UnityEngine;
using System.Collections;

public class L_Shape : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 18, 0);
		transform.localScale = new Vector3 (20, 20, 20);
		transform.rotation = new Quaternion (0, 0, 0, 0);
	}

	public void moveLeft(){
		Vector3 temp = transform.position;
		temp += new Vector3 (1, 0, 0);
		transform.position = temp;
	}
	public void moveRight(){
		Vector3 temp = transform.position;
		temp += new Vector3 (-1, 0, 0);
		transform.position = temp;
	}
	public void moveForward(){
		Vector3 temp = transform.position;
		temp += new Vector3 (0, 0, 1);
		transform.position = temp;	
	}
	public void moveBack(){
		Vector3 temp = transform.position;
		temp += new Vector3 (0, 0, -1);
		transform.position = temp;
	}
}
