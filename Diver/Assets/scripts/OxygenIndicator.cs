using UnityEngine;
using System.Collections;

public class OxygenIndicator : MonoBehaviour {
	public float level = 1.0f;
	float warning_level = 0.3f;
	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		float oxygen = OxygenBar.Oxygen();
		if (oxygen < warning_level) {
			guiTexture.texture = Resources.Load ("oxygenbar_red") as Texture;
		} else {
			guiTexture.texture = Resources.Load ("oxygenbar_green") as Texture;
		}
		if (oxygen <= level) {
			guiTexture.texture = Resources.Load ("oxygenbar_empty") as Texture;
		} 
	}
}
