using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGLooper : MonoBehaviour {

	public Transform coin;

	int numBGPanels = 6;
	int shineCounter = 0;

	float pipeMax = 0.8430938f;
	float pipeMin = 0.13243029f;
	HashSet<string> hs = new HashSet<string>();

	void Start() {
		hs.Add ("Sea");
		hs.Add("Sand");
		hs.Add("Shine");

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
				panelCount = 31;
				break;
			case "Sand":
				panelCount = 1;
				break;
			case "Shine":
				panelCount = 1;
				break;
			default:
				panelCount = numBGPanels;
				break;
		}

		Vector3 pos = collider.transform.position;
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		pos.x += widthOfBGObject * panelCount;

		if ("Shine" == collider.tag) {
			shineCounter++;
			if (shineCounter%2 == 0) {
				int r = Random.Range(0, 3);
				r = 2;
				string[] levels = {"LevelA", "Level_B", "Level_C"};
				Debug.Log (r);
				switch (r) {
					case 0: 
					pos.y = 1.25f;
					break;
					case 1:
					pos.y = 1.0f;
					break;
					case 2:
					pos.y = 1.0f;
					break;
				}
				// Put block
				GameObject obj = Resources.Load (levels[r], typeof(GameObject)) as GameObject;
				Instantiate (obj, pos, transform.rotation);
				obj = Resources.Load ("coin", typeof(GameObject)) as GameObject;
				Instantiate (obj, pos, transform.rotation);
			}
		}
		// Move bg, but kill everything else
		if (hs.Contains (collider.tag)) {
			if (collider.tag == "Shine") {
					pos.x += Random.Range (0, 1.0f);
					pos.y = Random.Range (pipeMin, pipeMax);
			}
			collider.transform.position = pos;
		}
 		else {
			Destroy(collider.gameObject);
		}

	}
}
