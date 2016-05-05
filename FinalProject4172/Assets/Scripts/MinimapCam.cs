using UnityEngine;
using System.Collections;

public class MinimapCam : MonoBehaviour {

	private Vector3 pos;
	private Plane[] planes;
	public GameObject head;
	public GameObject board;
	public Camera minimapCam;
	public GameObject headShadowPrefab;
	GameObject headShadow;


	void Start () {
		
//		pos = transform.position;
//		ARcam = GameObject.Find ("Camera");
		planes = GeometryUtility.CalculateFrustumPlanes(minimapCam);
	}
	

	void Update () {
		Vector3 boardToHead = head.transform.position - board.transform.position;
		planes = GeometryUtility.CalculateFrustumPlanes(minimapCam);
		float boardToHeadDistance = Vector3.Distance (head.transform.position, board.transform.position);
		bool hit = false;
		for(int i = 0; i < planes.Length; i++) {
			Plane p = planes [i];
			float hitDist;
			Ray r = new Ray (board.transform.position, boardToHead);

			if (p.Raycast (r, out hitDist)) {
				if (hitDist < boardToHeadDistance && hitDist > 0) {
					if (headShadow == null) {
						headShadow = Instantiate (headShadowPrefab);					
					}
					hit = true;

					headShadow.transform.position = board.transform.position + hitDist * Vector3.Normalize (boardToHead);
				}
			}
		}
		if (!hit) {
			Destroy (headShadow);
		}
	}


	void LateUpdate(){

	}
}
