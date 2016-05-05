using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

	public int level;

	public void youAreSelected(){
		LevelController.level = level;
		SceneManager.LoadScene ("MainScene");
	}
}
