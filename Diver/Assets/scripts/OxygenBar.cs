using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {
	static float oxygenMax = 1;
	static float oxygenLossRate = 0.05f;
	static float oxygenGainRate = 0.03f;
	static float oxygen = 1;

	public static void refillOxygen() {
		oxygen = oxygenMax;
	}

	public static void addOxygen() {
		oxygen += oxygenGainRate;
		if (oxygen > oxygenMax) {
			oxygen = oxygenMax;
		}
	}

	public static float Oxygen() {
		return oxygen;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygen -= oxygenLossRate * Time.deltaTime;
		oxygen = Mathf.Max (0.0f, oxygen);
		Rect rect = guiTexture.pixelInset;
		rect.width = 128.0f*oxygen;
		guiTexture.pixelInset = rect;
	}
	
	void FixedUpdate () {
		
	}
}
