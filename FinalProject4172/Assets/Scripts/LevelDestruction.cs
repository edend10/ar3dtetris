using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	ArrayList childBlocks = new ArrayList();



	// Use this for initialization
	void Start () {
		blockCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (childBlocks.Count == 25)
			destroyLevel (); 
	
	}

	void onCollisionEnter(Collision block) {

		childBlocks.Add (&block.rigidbody);
		Debug.Log ("added " + block.ToString () + " size: " + childBlocks.Count);

	}

	void onCollisionExit(Collision block) {
		
		childBlocks.RemoveAt (&childBlocks.Count);
		Debug.Log ("removed " + block.ToString () + " size: " + childBlocks.Count);

	}


	void destroyLevel() {
		for (int i = 0; i <= 25; ++i) {
			Destroy (childBlocks [i]);
		}
	}
}
