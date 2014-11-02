﻿using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public Transform coin;

	int numBGPanels = 6;

	float pipeMax = 0.8430938f;
	float pipeMin = -0.003243029f;

	void Start() {
//		GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
//
//		foreach(GameObject pipe in pipes) {
//			Vector3 pos = pipe.transform.position;
//			pos.y = Random.Range(pipeMin, pipeMax);
//			pipe.transform.position = pos;
//		}
		// Create some coins
//		GameObject coin = Instantiate(coin);
//		coin.transform.position = new Vector3(0, 0, 0);
//		Debug.Log ("BGLooper start");
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered: " + collider.name);

		int panelCount = numBGPanels;
		switch (collider.tag) {
			case "Sea":
				panelCount = 3;
				break;
			case "Sand":
			panelCount = 6;
				break;
			default:
				panelCount = numBGPanels;
				break;
		}


		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += widthOfBGObject * panelCount;

		if(collider.tag == "Pipe") {
			pos.y = Random.Range(pipeMin, pipeMax);
		}

		collider.transform.position = pos;

	}
}
