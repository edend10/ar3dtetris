using UnityEngine;
using System.Collections;

public class PowerUpActivator : MonoBehaviour {

	public GameObject destroyPowerUp;
	private float desHeight;

	void Start () {

		desHeight = 4.4f;
	}

	void Update () {

		//Debug.Log (Time.time);

		if (Time.time > 15 && Time.time < 21) {
			destroyPowerUp.gameObject.SetActive (true);
		}

		if (Time.time > 45 && Time.time < 45.5) {
			destroyPowerUp.transform.position = new Vector3(-2.2f, 6.4f, 0f);
			destroyPowerUp.gameObject.SetActive (true);
		}

		if (Time.time > 75 && Time.time < 76) {
			destroyPowerUp.transform.position = new Vector3(-2.2f, 6.4f, 0f);
			destroyPowerUp.gameObject.SetActive (true);
		}

		if (Time.time > 105 && Time.time < 106) {
			destroyPowerUp.transform.position = new Vector3(-2.2f, 6.4f, 0f);
			destroyPowerUp.gameObject.SetActive (true);
		}

		if (Time.time > 135 && Time.time < 136) {
			destroyPowerUp.transform.position = new Vector3(-2.2f, 6.4f, 0f);
			destroyPowerUp.gameObject.SetActive (true);
		}

	}
}