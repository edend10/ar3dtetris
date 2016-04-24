using UnityEngine;
using System.Collections;
using Vuforia;

public class DropBrickVirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

	GameObject activeBrick;

	public delegate void DropBrick();
	public static event DropBrick drop;

	// Use this for initialization
	void Start () {

		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		for (int i = 0; i < vbs.Length; i++) {
			vbs [i].RegisterEventHandler (this);
			Debug.Log ("dafaf");
		}

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {	

		Debug.Log ("Pressed");
		GameObject[] temp = GameObject.FindGameObjectsWithTag("active");
		if (temp.Length > 0) {
			activeBrick = temp [0];
			Rigidbody r = activeBrick.GetComponents<Rigidbody> ()[0];
			r.useGravity = true;
		}

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {	
		Debug.Log("Released");
		if (drop != null)
			drop();

	}

	void Update () {

	}

}