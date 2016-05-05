using UnityEngine;
using System.Collections;

public class PowerUpActivator : MonoBehaviour {

	public GameObject destroyPowerUp;
	private float desHeight;

	void Start () {

		desHeight = 4.4f;
	}

	void Update () {

		if (Time.time > 15 && Time.time < 21) {
			destroyPowerUp.gameObject.SetActive (true);
			Debug.Log (destroyPowerUp.transform.position);

		}

		if (Time.time > 45 && Time.time < 45.3) {
			destroyPowerUp.gameObject.SetActive (true);
			destroyPowerUp.transform.position = new Vector3 (-10.0f, 20.0f, 0f);
		}

		if (Time.time > 75 && Time.time < 76) {
			destroyPowerUp.gameObject.SetActive (true);
			destroyPowerUp.transform.position = new Vector3 (-10.0f, 20.0f, 0f);
		}

		if (Time.time > 105 && Time.time < 106) {
			destroyPowerUp.gameObject.SetActive (true);
			destroyPowerUp.transform.position = new Vector3 (-10.0f, 20.0f, 0f);
		}

		if (Time.time > 135 && Time.time < 136) {
			destroyPowerUp.gameObject.SetActive (true);
			destroyPowerUp.transform.position = new Vector3 (-10.0f, 20.0f, 0f);
		}

	}
}