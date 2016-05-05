using UnityEngine;
using System.Collections;

public class Projections : MonoBehaviour {

	public GameObject cube;
	public GameObject ground;
	private LineRenderer l1;

	void Start () {
		l1 = cube.AddComponent<LineRenderer>();
	}

	void Update () {
	
		l1.SetPosition (0, cube.transform.position);
		l1.SetPosition (1, ground.transform.position);
	}
}
