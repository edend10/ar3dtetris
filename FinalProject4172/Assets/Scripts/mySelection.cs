using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mySelection : MonoBehaviour
{
	
	GameObject hitObject;

	GameObject selectedObject;

	float startTime;

	public GameObject ARcamera;
	Transform cam;

	// Use this for initialization
	void Start ()
	{
		cam = Camera.main.transform;
	}
		
	// Update is called once per frame
	void Update ()
	{
		
		RaycastHit hit;
		cam = Camera.main.transform;
		Ray ray = new Ray (cam.position, cam.forward);

		if (Physics.Raycast (ray, out hit)) {
			GameObject o = hit.collider.gameObject;
			if (o == selectedObject) {
				
			} else if (o == hitObject) {
				//center.fontSize += 1;
				float endTime = Time.time;
				float time = endTime - startTime;
				if (time > 2) {
					Debug.Log ("Raycast: " + hit.collider.gameObject);
					selectedObject = hitObject;
					//center.color = Color.red;
				}
								
			} else {
				startTime = Time.time;
				hitObject = o;
			}
		} else {
			//center.fontSize = 12;
			//center.color = Color.black;
			hitObject = null;
		}
			
	}
			
}