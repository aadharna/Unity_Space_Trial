using UnityEngine;
using System.Collections;

public class Death_By_Contact : MonoBehaviour {

	public GameObject explosion, PlayerExplosion;
	public int scoreValue;
	private GameLoop gameController;

	void Start() {

		scoreValue = 11;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameLoop> ();
		}
		if (gameController == null) {
			Debug.Log ("Connot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("boundary")) {
			return;
		} else {

			Instantiate (explosion, transform.position, transform.rotation);

			if (other.CompareTag ("Player")) {
				Instantiate (PlayerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
			}

			gameController.addScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);

		}
	}
}