using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public GameObject L1, L2, L3;

	private Light halo;
	private bool powerReady;
	private bool goFast;
	private float tempTime = 200.0f;

	void Start () {
	
		L1 = GameObject.Find ("Level1");
		L2 = GameObject.Find ("Level2");
		L3 = GameObject.Find ("Level3");

		halo = GetComponent<Light>();

		powerReady = true;
		goFast = false;
		gameObject.SetActive (false);

	}
	

	void Update () {

			
		if (powerReady) {
			Glow (10, 0.5f);
			transform.Rotate (new Vector3 (45, 45, 45) * Time.deltaTime);
		}

		if (goFast) {
			Glow (50, 2.0f);
		}

		if (transform.position.y < 1) {
			gameObject.SetActive(false);
		}

		if ((Time.time - tempTime) > 1.2) {
			gameObject.SetActive (false);
		}
			
	}

	public void youAreSelected(){
		tempTime = Time.time;
		Debug.Log ("tempTime is " + tempTime);
		halo.color = Color.green;
		goFast = true;

		Destroy (L1);

	}

	public void Destroy(GameObject g){

		Debug.Log("we destroyin");
		g.GetComponent<LevelDestruction> ().DestroyLevel ();
	}

	public void Glow(int speed, float range){

		halo.range = 3.0f + Mathf.Sin(Time.time * speed) * range;
	}

}
