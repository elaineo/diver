using UnityEngine;
using System.Collections;

public class fontResize : MonoBehaviour {
	const float REFERENCE_SCREEN_WIDTH = 800.0f;

	// Use this for initialization
	void Start () {
		float scaleFactor = (Screen.width/REFERENCE_SCREEN_WIDTH);
		guiText.fontSize = (int)(24*scaleFactor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
