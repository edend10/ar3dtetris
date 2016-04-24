﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

	public Text center;
	GameObject hitObject;

	GameObject selectedObject;

	float startTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Transform cam = Camera.main.transform;
		Ray ray = new Ray(cam.position, cam.forward);

		if (Physics.Raycast (ray, out hit)) {
			center.fontSize = 14;
			GameObject o = hit.collider.gameObject;
			if (o == hitObject) {
				float endTime = Time.time;
				float time = endTime - startTime;
				if (time > 2) {
					Debug.Log ("Raycast: " + hit.collider.gameObject);
					selectedObject = hitObject;
				}
				
			} else {
				startTime = Time.time;
			}
		} else {
			center.fontSize = 12;
		}
	
	}
		
}
