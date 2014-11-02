using UnityEngine;
using System.Collections;

public class CoinSpawner : Spawner {
	public override void Spawn() {
		// Instantiate a random enemy.
		for (int i = 0; i < 9; i++) {
			int enemyIndex = Random.Range (0, enemies.Length);
			int x = i % 3;
			int y = i / 3;
			Vector3 pos = transform.position;
			pos.y += y * 0.2f;
			pos.x += x * 0.2f;
			Instantiate (enemies [enemyIndex], pos, transform.rotation);
		}
	}
}
