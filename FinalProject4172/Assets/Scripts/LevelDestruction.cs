using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();
	GameObject currentChild;
	int numToClear = 25;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CheckIfFull", 0, GameController.releaseTimer + 3);
	}

	void Update() {
//		if (GameController.readyToCheck)
//			CheckIfFull ();
	}

	public void CheckIfFull() {
		if (!Pause.paused && !Pause.targetLost) {
			if (childBlocks.Count >= numToClear) {
				DestroyLevel ();
			}
		}
	}

	public void DestroyLevel( ) {
		while (childBlocks.Count > 0) {
			currentChild = (GameObject)childBlocks [childBlocks.Count-1];
			childBlocks.RemoveAt (childBlocks.Count-1);
			currentChild.SetActive (false);
			Destroy (currentChild);
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
