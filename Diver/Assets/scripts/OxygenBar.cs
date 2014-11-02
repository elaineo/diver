using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {
	static float oxygenMax = 1;
	static float oxygenRate = 0.05f;
	static float oxygen = 1;

	public static void addOxygen(float amount) {
		oxygen += amount;
		if (oxygen > oxygenMax) {
			oxygen = oxygenMax;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygen -= oxygenRate * Time.deltaTime;
		oxygen = Mathf.Max (0.0f, oxygen);
		Rect rect = guiTexture.pixelInset;
		rect.width = 128.0f*oxygen;
		guiTexture.pixelInset = rect;
		
	}
	
	void FixedUpdate () {
		
	}
}
