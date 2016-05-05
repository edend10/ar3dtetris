using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void youAreSelected(){
		GameController.releaseTimer = 8f; 
		LevelController.level = 0;
		LevelController.levelsCleared = 0;
		LevelController.totalLevelsCleared = 0;

		ControlInstructions.n = 0;

		Destroy (GameController.activeBrick);
		GameController.activeBrick = null;

		Destroy (GameController.ghostBrick);
		GameController.ghostBrick = null;

		SceneManager.LoadScene ("Menu");
	}
}
