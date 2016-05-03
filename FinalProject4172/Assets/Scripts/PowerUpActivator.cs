using UnityEngine;
using System.Collections;

public class PowerUpActivator : MonoBehaviour {

	public GameObject destroyPowerUp;

	void Start () {

	}

	void Update () {

		if (Time.time > 10 && Time.time < 12) {
			destroyPowerUp.gameObject.SetActive (true);
		}
	}
}