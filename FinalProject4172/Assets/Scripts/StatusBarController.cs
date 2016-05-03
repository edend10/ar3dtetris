using UnityEngine;
using System.Collections;

public class StatusBarController : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("showBox", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <= GameController.releaseTimer; ++i) {
			float obj = GameController.releaseTimer - 10;
			string temp = "StatusCube" + obj;
			Debug.Log (temp + " not active");

			//GameObject.Find (temp).SetActive (false);
		}
	}


	void showBox() {
		for (int i = 0; i <= GameController.releaseTimer; ++i) {
			string temp = "StatusCube" + i;

			GameObject.Find (temp).SetActive (true);
			Debug.Log (temp + " active" );
		}
	}


}
