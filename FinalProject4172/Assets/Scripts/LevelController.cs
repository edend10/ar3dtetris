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

		InvokeRepeating ("CheckLevel", 2, 2);
	}
	
	// Update is called once per frame
	void CheckLevel () {


		if (levelsCleared == 5) {
			++level;
			GameController.timer -= 2;
			//Debug.Log (level);
			levelText.text = "Level: " + level;
		}
	
	}
}
