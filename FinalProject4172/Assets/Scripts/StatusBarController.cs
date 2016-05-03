using UnityEngine;
using System.Collections;

public class StatusBarController : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
		InvokeRepeating ("showBox", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
//		if (GameController.releaseTimer % 1 == 0) {
//
//			for (int i = 0; i <= GameController.releaseTimer; ++i) {
//				showBox (i);
//			}
//		}
//		if (GameController.releaseTimer % 1 == 0) {
//			//removeBox ();
//		}

	}


	void showBox() {
		for (int i = 0; i <= GameController.releaseTimer; ++i) {
			GameObject.Find ("StatusCube" + i).SetActive (true);
			Debug.Log (i + " statuscube");
		}
	}

	void removeBox(int i) {

		GameObject.Find ("StatusCube" + i).SetActive (false);

	
	}
}
