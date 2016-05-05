using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mySelection : MonoBehaviour
{
	
	public GameObject center;
	public Material normalMaterial;
	public Material selectedMaterial;

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
			int layer = o.layer;
			if (layer == 8) {
			} 
			else {
				float endTime = Time.time;
				float time = endTime - startTime;
				if (o == selectedObject) {
					if (time > 4) {
						selectedObject = null;
					}
					center.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
					Renderer r = center.GetComponents<Renderer> () [0];
					r.material = normalMaterial;
				
				} else if (o == hitObject) {
					center.transform.localScale += new Vector3 (0.005f, 0.005f, 0.005f);
					if (time > 2) {
						selectedObject = hitObject;
						Renderer r = center.GetComponents<Renderer> () [0];
						r.material = selectedMaterial;
						selectedObject.SendMessage ("youAreSelected");
					}
								
				} else {
					startTime = Time.time;
					hitObject = o;
				}
			}
		} else {
			center.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);

			Renderer r = center.GetComponents<Renderer> () [0];
			r.material = normalMaterial;
			hitObject = null;
		}
			
	}
			
}