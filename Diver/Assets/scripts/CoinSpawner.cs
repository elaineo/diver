using UnityEngine;
using System.Collections;

public class CoinSpawner : Spawner {
	public GameObject coin;
	GameObject powerUp;

	public override void Spawn() {
		// Instantiate a random enemy.
		AddCoins ();
//		int index = Random.Range (0, 2);
//		switch (index) {
//		case 0:
//			AddCoins();
//			break;
//		case 1:
//			AddPowerUp();
//			break;
//		}
	}
	
	void AddCoins() {
		for (int i = 0; i < 9; i++) {
			int x = i % 3;
			int y = i / 3;
			Vector3 pos = transform.position;
			pos.y += y * 0.2f;
			pos.x += x * 0.2f;
			Add (coin, pos);
		}
	}

	void AddPowerUp() {
		Vector3 pos = transform.position;
		pos.y += 0.5f;
		pos.x += 0.5f;
		Add (powerUp, pos);
	}
	
	void Add(GameObject obj, Vector3 position) {
		Instantiate (obj, position, transform.rotation);
	}
}
