﻿using UnityEngine;
using System.Collections;

public class CoinSpawner : Spawner {
	public GameObject coin;
	public int coinRate = 10;
	public GameObject powerUp;
	public int powerUpRate = 5;
	public GameObject bubble;
	public int bubbleRate = 30;

	public override void Spawn() {
		// Instantiate a random enemy.
		int index = Random.Range (0, 100);
		if (index < coinRate) {
			AddCoins ();
		}
		if (index < powerUpRate) {
			AddPowerUp();
		}

		if (index < bubbleRate) {
			AddBubble();
		}
	}

	void AddCoins() {
		int pattern = Random.Range (0, 3);
		Vector3 pos = transform.position;
		switch (pattern) {
		// Square
		case 0:
			for (int i = 0; i < 9; i++) {
				int x = i % 3;
				int y = i / 3;
				Add (coin, new Vector3(pos.x + x * 0.2f, pos.y + y * 0.2f, pos.z));
			}
			break;
		// Star
		case 1:
			Add (coin, new Vector3(pos.x - 0.2f, pos.y, pos.z));
			Add (coin, new Vector3(pos.x, pos.y + 0.2f, pos.z));
			Add (coin, new Vector3(pos.x + 0.2f, pos.y, pos.z));
			Add (coin, new Vector3(pos.x, pos.y - 0.2f, pos.z));
			break;
		// Line
		case 2:
			for (int i = 0; i < 5; i++) {
				int iAdj = i - 2;
				Add (coin, new Vector3(pos.x + 0.2f * i, pos.y, pos.z));
				Add (coin, new Vector3(pos.x + 0.2f * i, pos.y - 0.2f, pos.z));
			}
			break;
		}
	}

	void AddPowerUp() {
		Vector3 pos = transform.position;
		Add (powerUp, pos);
	}

	void AddBubble() {
		Vector3 pos = transform.position;
		pos.y -= 0.5f;
		Add (bubble, pos);
	}
	
	void Add(GameObject obj, Vector3 position) {
		Instantiate (obj, position, transform.rotation);
	}
}
 