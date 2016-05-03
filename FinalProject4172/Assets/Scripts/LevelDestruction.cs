using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;
	int numToClear = 5;




	// Use this for initialization
	void Start () {
		InvokeRepeating ("CheckIfFull", 2, 1);

	}

	void CheckIfFull() {
		if (childBlocks.Count >= numToClear) {
			DestroyLevel ();
		}
	}

	public void DestroyLevel( ) {
		Debug.Log("destroy level " + gameObject.name);
		while (childBlocks.Count > 0) {
			currentChild = (GameObject)childBlocks [childBlocks.Count-1];
			childBlocks.RemoveAt (childBlocks.Count-1);
			currentChild.SetActive (false);
		}
		if (LevelController.levelsCleared < 5) {
			++LevelController.levelsCleared;
			++LevelController.totalLevelsCleared;
		}

	}

	void OnTriggerEnter(Collider block) {
		childBlocks.Add(block.gameObject);

	}

	void OnTriggerExit (Collider block) {
		childBlocks.Remove (block.gameObject);
	}


}
