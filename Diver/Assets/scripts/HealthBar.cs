using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	static float health = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		health -= 0.1f * Time.deltaTime;
		health = Mathf.Max (0.0f, health);
		Rect rect = guiTexture.pixelInset;
		rect.width = 128.0f*health;
		guiTexture.pixelInset = rect;
	 
	}
	
	void FixedUpdate () {
		
	}
}
