using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	public static float levelsCleared = .0f;

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;
	int numToClear = 10;



	// Use this for initialization
	void Start () {

		InvokeRepeating ("CheckIfFull", 2, 1);

	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void CheckIfFull() {
		if (childBlocks.Count >= numToClear) {
			DestroyLevel ();
		}
	}

	void DestroyLevel( ) {

		//int arrSize = childBlocks.Count;

		while (childBlocks.Count > 0) {
			currentChild = (GameObject)childBlocks [childBlocks.Count-1];
			//Debug.Log (currentChild.ToString () + " is trashed"); 
			childBlocks.RemoveAt (childBlocks.Count-1);
			currentChild.SetActive (false);
		}

		++levelsCleared;

		//Debug.Log (childBlocks.Count);

	}

	void OnTriggerEnter(Collider block) {
		childBlocks.Add(block.gameObject);
		//Debug.Log (gameObject.name + " added " + block.gameObject.ToString () + " size: " + childBlocks.Count);

	}

	void OnTriggerExit (Collider block) {
		//childBlocks.RemoveAt(childBlocks.Count-1);
		childBlocks.Remove (block.gameObject);
		//Debug.Log (gameObject.name + " removed " + block.gameObject.ToString () + " size: " + childBlocks.Count);
	}


}
