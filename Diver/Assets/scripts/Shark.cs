﻿using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {

	int numberOfDirectionChanges = 0;
	float sharkSpeed = 1.5f;
	bool goingUp = false;
	float forwardSpeed = -0.2f;
	public int maxNumberOfDirectionChanges = 3;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		float player_y = player_go.rigidbody2D.position.y;
		float shark_y = rigidbody2D.position.y;
		if (player_y > shark_y) {
			rigidbody2D.AddForce (Vector2.up * sharkSpeed);
			goingUp = true;
		} else {
			rigidbody2D.AddForce (-Vector2.up * sharkSpeed);
			goingUp = false;
		}
		Debug.Log (player_y);
		Debug.Log (shark_y);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		float player_y = player_go.rigidbody2D.position.y;
		float shark_y = rigidbody2D.position.y;

		rigidbody2D.AddForce( Vector2.right * forwardSpeed );

		if (numberOfDirectionChanges < maxNumberOfDirectionChanges) {
			if (player_y > shark_y) {
				rigidbody2D.AddForce (Vector2.up * sharkSpeed);
				if (! goingUp) {
					goingUp = true;
					numberOfDirectionChanges += 1;
				}
			} else {
				rigidbody2D.AddForce (-Vector2.up * sharkSpeed);
				if (goingUp) {
					goingUp = false;
					numberOfDirectionChanges += 1;
				}
			}
		}
		Vector3 pos = rigidbody2D.position;
		rigidbody2D.position = pos;
	}
}