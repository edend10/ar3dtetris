using UnityEngine;
using System.Collections;

public class BrickControl : MonoBehaviour {

	GameObject activeBrick;

	// Use this for initialization
	void Start () {
		activeBrick = GameObject.Find ("tempbrick"); //temp
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")){ 
			activeBrick.transform.Rotate (90,0,0);
		}
		else if(Input.GetKeyDown("a")){
			activeBrick.transform.Rotate (-90,0,0);
		}
		else if(Input.GetKeyDown("w")){
			activeBrick.transform.Rotate (0,90,0);
		}
		else if(Input.GetKeyDown("s")){
			activeBrick.transform.Rotate (0,-90,0);
		}
		else if(Input.GetKeyDown("e")){
			activeBrick.transform.Rotate (0,0,90);
		}
		else if(Input.GetKeyDown("d")){
			activeBrick.transform.Rotate (0,0,-90);
		}

	}
}
