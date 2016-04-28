using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;
	int numToClear = 25;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (childBlocks.Count >= numToClear)
			destroyLevel (); 
	
	}

	void OnTriggerEnter(Collider block) {
		childBlocks.Add(block.gameObject);
		Debug.Log ("added " + block.gameObject.ToString () + " size: " + childBlocks.Count);

	}

	void OnTriggerExit (Collider block) {
		childBlocks.Remove(block.gameObject);
		Debug.Log ("removed " + block.gameObject.ToString () + " size: " + childBlocks.Count);
	}


	void destroyLevel() {

		for (int i = 0; i <= numToClear; ++i) {
			currentChild = (GameObject)childBlocks [i];
			currentChild.SetActive (false);
			childBlocks.Remove (currentChild);
		}

		Debug.Log (childBlocks.Count);

	}
}
