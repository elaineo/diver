using UnityEngine;
using System.Collections;

public class guiScale : MonoBehaviour {
	const float REFERENCE_SCREEN_WIDTH = 800.0f;
	// Use this for initialization
	void Start () {
		float scaleFactor = (Screen.width/REFERENCE_SCREEN_WIDTH);
		foreach (GUITexture t in GetComponentsInChildren<GUITexture>()) {
			Rect r = t.pixelInset;
			r.x *= scaleFactor;
			r.y *= scaleFactor;
			r.width *= scaleFactor;
			r.height *= scaleFactor;
			t.pixelInset = r;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
