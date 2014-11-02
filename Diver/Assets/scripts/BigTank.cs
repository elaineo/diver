using UnityEngine;
using System.Collections;

public class BigTank : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float oxygen = OxygenBar.Oxygen();
		byte oxygenColor = 100;
		int o = (int)((1-oxygen) * 100);
		oxygenColor = (byte)o;
		guiTexture.color =  new Color32(255, 255, 255, oxygenColor);
		//GUI.color =  new Color32(255, 255, 255, 10);
	}
}
