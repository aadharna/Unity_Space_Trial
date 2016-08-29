using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour {

	public GameObject hazard;
	public Vector3 Spawn_Value;
	public float spawn_wait, start_wait, wave_wait;
	public int Hazard_Count;
	public GUIText restartText, game_over_text, scoreText, waveText;

	private bool gameOver, restart;
	private int score, wave;

	void Start() {

		restartText.text = " ";
		game_over_text.text = " ";
		waveText.text = " ";
		updateScore ();
		gameOver = false;
		restart = false;
		StartCoroutine (spawnWaves ());
	}

	void Update() {

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {

				SceneManager.LoadScene ("Main");
				//Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator spawnWaves() {

		yield return new WaitForSeconds (start_wait);

		while (true) {
			wave += 1;
			updateWave ();
			for (int i = 0; i < Hazard_Count; i++) {
				Vector3 Spawn_Position = new Vector3 (
					Random.Range (-Spawn_Value.x, Spawn_Value.x), Spawn_Value.y, Spawn_Value.z);
		
				Quaternion Spawn_Rotation = Quaternion.identity;
				Instantiate (hazard, Spawn_Position, Spawn_Rotation);

				yield return new WaitForSeconds (spawn_wait);
			}

			yield return new WaitForSeconds (wave_wait);

			if (gameOver) {

				restartText.text = "Press 'R' to restart the game";
				restart = true;
				break;
			}
		}
	}

	public void addScore(int newScoreValue) {

		score += newScoreValue;
		updateScore ();

	}

	void updateWave() {
		waveText.text = "Wave: " + wave;
	}

	void updateScore() {

		scoreText.text = "Score: " + score;

	}
		
	public void GameOver() {

		game_over_text.text = "Game Over";
		gameOver = true;
	}
}