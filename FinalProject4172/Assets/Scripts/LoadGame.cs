using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	public int level = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void youAreSelected(){
		LevelController.level = level;
		SceneManager.LoadScene ("MainScene");
	}
}
