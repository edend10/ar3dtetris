using UnityEngine;
using System.Collections;

public class QuadController : MonoBehaviour {

	private Camera ARcam;
	private Vector3 offset;

	void Start () {

		ARcam = GameObject.Find ("StereoCameraLeft").GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		offset = ARcam.transform.forward * 5 + ARcam.transform.right * 2 + ARcam.transform.up ;
		transform.position = ARcam.transform.position + offset;
	}
}
