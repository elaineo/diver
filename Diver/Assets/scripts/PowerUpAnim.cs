using UnityEngine;
using System.Collections;

public class PowerUpAnim : MonoBehaviour {
	float elapsedTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		Color c = renderer.material.color;
		c.a = 0.5f + Mathf.Sin (3.0f * elapsedTime);
		renderer.material.color = c;
	}
}
