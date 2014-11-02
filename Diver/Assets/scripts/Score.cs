using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;
	static int coins = 0;

	static Score instance;

	static public void AddPoint() {
		if(instance.player.dead)
			return;

//		score++;

		if(score > highScore) {
			highScore = score;
		}
	}

	static public void AddCoin() {
		coins++;
	}

	Player player;

	void Start() {
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}

		player = player_go.GetComponent<Player>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
		coins = 0;
		//coins = PlayerPrefs.GetInt ("coins", 0);
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt("highScore", highScore);
		// PlayerPrefs.SetInt("coins", coins);
	}

	void Update () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		score = (int)player_go.rigidbody2D.position.x * coins;
		AddPoint ();
		guiText.text = "Coins: "+ coins.ToString("F0") + "\nScore: " + score.ToString("F0") + "\nHigh Score: " + highScore.ToString("F0");
	}
}
