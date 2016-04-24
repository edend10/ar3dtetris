using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (childBlocks.Count == 25)
			destroyLevel (); 
	
	}

	void onCollisionEnter(Collision block) {

		childBlocks.Add (block.rigidbody.gameObject);
		Debug.Log ("added " + block.rigidbody.gameObject.ToString () + " size: " + childBlocks.Count);

	}

	void onCollisionExit(Collision block) {
		
		childBlocks.RemoveAt (childBlocks.Count);
		Debug.Log ("removed " + block.rigidbody.gameObject.ToString () + " size: " + childBlocks.Count);
	}


	void destroyLevel() {
		for (int i = 0; i <= 25; ++i) {
			currentChild = (GameObject)childBlocks [i];
			currentChild.SetActive (false);
		}
	}
}
