using UnityEngine;
using System.Collections;

public class PowerUpActivator : MonoBehaviour {

	public GameObject destroyPowerUp;

	void Start () {

	}

	void Update () {

		if (Time.time > 5 && Time.time < 6) {
			destroyPowerUp.gameObject.SetActive (true);
		}
	}
}