using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public GameObject instructions;
	public GameObject Main;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void youAreSelected(){
		Main.SetActive (false);
		instructions.SetActive (true);
	}
}
