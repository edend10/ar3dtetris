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
		SceneManager.LoadScene ("Menu");
	}
}
