using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;
	int numToClear = 5;



	// Use this for initialization
	void Start () {

		InvokeRepeating ("DestroyLevel", 2, 2);

	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void DestroyLevel( ) {

		if (childBlocks.Count >= numToClear) {
			
			Debug.Log ("DestroyLevel " + Time.time + " " + gameObject.name);
			for (int i = 0; i < numToClear; ++i) {
				currentChild = (GameObject)childBlocks [i];
				Debug.Log (currentChild.ToString () + " is trashed"); 

				currentChild.SetActive (false);
				//childBlocks.Remove (currentChild);
			}

			Debug.Log (childBlocks.Count);
		}

	}

	void OnTriggerEnter(Collider block) {
		childBlocks.Add(block.gameObject);
		Debug.Log (gameObject.name + " added " + block.gameObject.ToString () + " size: " + childBlocks.Count);

	}

	void OnTriggerExit (Collider block) {
		Debug.Log ("hello");
		childBlocks.RemoveAt(childBlocks.Count-1);
		Debug.Log (gameObject.name + " removed " + block.gameObject.ToString () + " size: " + childBlocks.Count);
	}


	void destroyLevel() {


	}
}
