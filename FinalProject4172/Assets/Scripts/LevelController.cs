using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public static int level;

	// Use this for initialization
	void Start () {
	
		level = 0;

	}
	
	// Update is called once per frame
	void Update () {


		if ((LevelDestruction.levelsCleared % 5)==0) {
			++level;
			GameController.timer -= 2;
		}
	
	}
}
