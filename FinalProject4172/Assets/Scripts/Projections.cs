using UnityEngine;
using System.Collections;

public class Projections : MonoBehaviour {

	public GameObject cube;
	public GameObject ground;
	private LineRenderer l1;

	// Use this for initialization
	void Start () {
		l1 = cube.AddComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	
		l1.SetPosition (0, cube.transform.position);
		l1.SetPosition (1, ground.transform.position);
	}
}
