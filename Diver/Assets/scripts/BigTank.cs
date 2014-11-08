using UnityEngine;
using System.Collections;

public class BigTank : MonoBehaviour {
	float time = 0;
	float frequency = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float oxygen = OxygenBar.Oxygen();
		if (oxygen < 0.3f) {
			time += Time.deltaTime;
			oxygen = Mathf.Sin (2.0f * Mathf.PI * time * frequency) * 0.5f + 0.5f;
			byte oxygenColor = 100;
			int o = (int)((1 - oxygen) * 100);
			oxygenColor = (byte)o;
			guiTexture.color = new Color32 (255, 255, 255, oxygenColor);
			//GUI.color =  new Color32(255, 255, 255, 10);
		} else {
			guiTexture.color = new Color32 (255, 255, 255, 0);
		}
	}
}
