using UnityEngine;
using System.Collections;
using Vuforia;

public class DropBrickVirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {


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

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {	
		Debug.Log("Released");
	}

	void Update () {

	}

}