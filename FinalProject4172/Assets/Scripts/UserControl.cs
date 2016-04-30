﻿using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	public GameObject head;

	float fixedDistance = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetPosition = gameObject.transform.position;
		Vector3 headPosition = head.transform.position;

		float z = Mathf.Abs(targetPosition.z - headPosition.z);

		float displacement = z - fixedDistance;
		Vector3 move = new Vector3 (0, 0, displacement);
		head.transform.position += move;
	
	}
}
