using UnityEngine;
using System.Collections;

public class LevelDestruction : MonoBehaviour {

	static int blockCount;
	ArrayList childBlocks = new ArrayList();



	// Use this for initialization
	void Start () {
		blockCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (blockCount == 25)
			destroyLevel (); 
	
	}

	void onCollisionEnter(Collision block) {

		++blockCount;
		childBlocks.Add (block.rigidbody);

	}

	void onCollisionExit(Collision block) {
		--blockCount;
		childBlocks.Remove (block.rigidbody);
	}


	void destroyLevel() {
		
	}
}
