using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.

	Transform player;

	float offsetX;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);

		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if(player_go == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}

		player = player_go.transform;

		offsetX = transform.position.x - player.position.x;

	}

	void Update () {
		if(player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}
