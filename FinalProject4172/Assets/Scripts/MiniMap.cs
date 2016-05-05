using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {

	public Vector3 headPosition;
	public Camera ARcam;
	private GameObject head;
	private Collider headCol;
	private bool isHeadVisible;

	void Start () {
		ARcam = ARcam.GetComponent<Camera> ();
		head = GameObject.Find ("Head");
		headCol = head.GetComponent<CapsuleCollider> ();
	}
	
	void Update () {
		headPosition = ARcam.transform.position - (ARcam.transform.worldToLocalMatrix.MultiplyVector(transform.forward));;
		head.transform.position = headPosition;

		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(ARcam);
		//isHeadVisible = GeometryUtility.TestPlanesAABB(planes, headCol.bounds);

	}
}
