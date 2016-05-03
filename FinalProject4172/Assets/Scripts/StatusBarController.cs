using UnityEngine;
using System.Collections;

public class StatusBarController : MonoBehaviour {

	private Vector3 initBarScale;

	// Use this for initialization
	void Start () {

		initBarScale = new Vector3(1.0f, 0.1f, 0.1f);
		InvokeRepeating ("scaleBoxDown", 0f, .9f);

	}

	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <= GameController.releaseTimer; ++i) {
			float obj = GameController.releaseTimer - 10;
			string temp = "StatusCube" + obj;


			//GameObject.Find (temp).SetActive (false);
		}
	}



	void scaleBoxDown() {

		if (GameController.time < GameController.releaseTimer && GameController.time <= GameController.createTimer) {
			float f = (1 / GameController.releaseTimer);

			if (gameObject.transform.localScale.x > 0)
				gameObject.transform.localScale -= new Vector3 (f, 0, 0);
			else {
				gameObject.transform.localScale = initBarScale;
			}
				
	
			GameObject.Find (temp).SetActive (true);

		}

	}

}
