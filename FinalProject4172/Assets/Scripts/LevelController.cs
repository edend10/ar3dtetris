using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	TextMesh levelText;
	public static int levelsCleared;
	public static int level;



	// Use this for initialization
	void Start () {
	
		level = 0;
		levelsCleared = 0;

		levelText = GameObject.Find("LevelNumber").GetComponent<TextMesh> ();
		levelText.text = level.ToString ();
		InvokeRepeating ("CheckLevel", 2, .5f);
	}
	
	// Update is called once per frame
	void CheckLevel () {

		//Debug.Log ("showTimer " + GameController.showTimer); 

		if (levelsCleared == 5) {
			++level;
			if (GameController.timer > 0) 
				GameController.timer -= 2;
			Debug.Log ("level " + level + " timer " + GameController.timer);
			levelText.text = level.ToString ();
			levelsCleared = 0;
		}
	
	}
}
