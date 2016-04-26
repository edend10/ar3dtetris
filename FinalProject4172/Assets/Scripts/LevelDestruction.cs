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

		if (childBlocks.Count == 2)
			destroyLevel (); 
	
	}

	//void onCollisionEnter(Collision block) {
	void onTriggerEnter(Collider block) {
		Debug.Log ("entered");
		//childBlocks.Add (block.rigidbody.gameObject);
		childBlocks.Add(block.gameObject);
		//Debug.Log ("added " + block.rigidbody.gameObject.ToString () + " size: " + childBlocks.Count);
		Debug.Log ("added " + block.gameObject.ToString () + " size: " + childBlocks.Count);

	}

	//void onCollisionExit(Collision block) {
	void onTriggerExit (Collider block) {
		Debug.Log ("exit");
		childBlocks.RemoveAt (childBlocks.Count);
		//Debug.Log ("removed " + block.rigidbody.gameObject.ToString () + " size: " + childBlocks.Count);
		Debug.Log ("removed " + block.gameObject.ToString () + " size: " + childBlocks.Count);
	}


	void destroyLevel() {
		for (int i = 0; i <= 2; ++i) {
			currentChild = (GameObject)childBlocks [i];
			currentChild.SetActive (false);
		}
	}
}
