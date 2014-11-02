using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {

	static float oxygen = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygen -= 0.05f * Time.deltaTime;
		oxygen = Mathf.Max (0.0f, oxygen);
		Rect rect = guiTexture.pixelInset;
		rect.width = 128.0f*oxygen;
		guiTexture.pixelInset = rect;
		
	}
	
	void FixedUpdate () {
		
	}
}
