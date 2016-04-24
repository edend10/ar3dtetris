using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

	public Text center;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Transform cam = Camera.main.transform;
		Ray ray = new Ray(cam.position, cam.forward);

		if (Physics.Raycast (ray, out hit)) {
			Debug.Log ("Raycast: " + hit.collider.gameObject);
			GameObject o = hit.collider.gameObject;
		}
	
	}
		
}
