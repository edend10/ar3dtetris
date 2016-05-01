using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public static int levelsCleared;
	public static int level;
	private GUIText levelText;

	// Use this for initialization
	void Start () {
	
		level = 0;
		levelsCleared = 0;

		levelText = GameObject.FindGameObjectWithTag ("LevelText").GetComponent<GUIText> ();
		levelText.text = "Level " + level; 
		//levelText = "Level " + level;

		InvokeRepeating ("CheckLevel", 2, .5f);
	}
	
	// Update is called once per frame
	void CheckLevel () {

		//Debug.Log ("showTimer " + GameController.showTimer); 

		if (levelsCleared == 1) {
			++level;
			GameController.timer -= 2;
			Debug.Log ("level " + level + " timer " + GameController.timer);
//			levelText.text = "Level: " + level;
			levelsCleared = 0;
		}
	
	}
}
