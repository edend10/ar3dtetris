using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public bool isFalling;
	public GameObject tL1, tL2, tL3;

	void Start () {
	
		tL1 = GameObject.Find ("Level 1");
		tL2 = GameObject.Find ("Level 2");
		tL3 = GameObject.Find ("Level 3");

	}
	

	void Update () {
			
	}

	public void youAreSelected(){
		Debug.Log ("selected: " + gameObject);

		GetComponent<Renderer>().material.color = Color.yellow;

		Destroy (tL1);
		Destroy (tL2);
		Destroy (tL3);

	}

	public void Destroy(GameObject g){

		g.GetComponent<LevelDestruction> ().DestroyLevel ();
	}

}
