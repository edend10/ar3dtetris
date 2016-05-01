using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	InvokeRepeating("Blink", 0, 0.4);

	public bool isFalling;

	void Start () {
	
	}
	

	void Update () {
			
	}

	public void youAreSelected(){
		Debug.Log ("selected: " + gameObject);

	}


	public void Blink() {
		renderer.enabled = false;
		yield WaitForSeconds(0.2);
		renderer.enabled = true;
	}

}
