using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	TextMesh levelText;
	TextMesh levelsClearedText; 
	public static int levelsCleared;
	public static int level = 0;
	public static int totalLevelsCleared;



	// Use this for initialization
	void Start () {
	
		//level = 0;
		levelsCleared = 0;
		totalLevelsCleared = 0;

		levelText = GameObject.Find("LevelNumber").GetComponent<TextMesh> ();
		levelText.text = level.ToString ();

		levelsClearedText = GameObject.Find ("TotalClearedNumber").GetComponent<TextMesh> ();
		levelsClearedText.text = totalLevelsCleared.ToString ();

		InvokeRepeating ("CheckLevel", 2, .5f);


	}
	

	void CheckLevel () {

		//Debug.Log ("showTimer " + GameController.showTimer); 

		levelsClearedText.text = totalLevelsCleared.ToString ();

		if (levelsCleared == 5) {
			++level;
			//Debug.Log (level);
			levelText.text = "Level: " + level;
			if (GameController.releaseTimer > 1) {
				GameController.createTimer -= 2;
				GameController.releaseTimer -= 2;
			}
			Debug.Log ("level " + level + " timer " + GameController.releaseTimer);
			levelText.text = level.ToString ();
			levelsCleared = 0;
		}
	
	}
}