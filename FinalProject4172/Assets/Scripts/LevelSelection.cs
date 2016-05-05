using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public GameObject levels;
	public GameObject Main;

	public void youAreSelected(){
		if (levels.activeSelf == false) {
			levels.SetActive (true);
			Main.SetActive (false);
		} 
		else {
			levels.SetActive (false);
			Main.SetActive (true);
		}

	}
}
