using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;
	int numToClear = 3;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (childBlocks.Count == numToClear)
			destroyLevel (); 
	
	}

	//void onCollisionEnter(Collision block) {
	void OnTriggerEnter(Collider block) {
		Debug.Log ("enter " + block.name);
	//	childBlocks.Add (block.rigidbody.gameObject);
		childBlocks.Add(block.gameObject);
	//	Debug.Log ("added " + block.rigidbody.gameObject.ToString () + " size: " + childBlocks.Count);
		Debug.Log ("added " + block.gameObject.ToString () + " size: " + childBlocks.Count);

	}

	//void onCollisionExit(Collision block) {
	void OnTriggerExit (Collider block) {
		Debug.Log ("exit " + block.name);
		childBlocks.RemoveAt (childBlocks.Count);
		//Debug.Log ("removed " + block.rigidbody.gameObject.ToString () + " size: " + childBlocks.Count);
		Debug.Log ("removed " + block.gameObject.ToString () + " size: " + childBlocks.Count);
	}


	void destroyLevel() {

		for (int i = 0; i <= numToClear; ++i) {
			currentChild = (GameObject)childBlocks [i];
			currentChild.SetActive (false);
		}

		childBlocks.Clear ();
		Debug.Log (childBlocks.Count);

	}
}
