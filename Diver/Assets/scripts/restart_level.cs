using UnityEngine;
using System.Collections;

public class restart_level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int count = Input.touchCount;
		for (int i = 0; i < count; i++) {
			Touch touch = Input.GetTouch (i);
			if (guiTexture.HitTest (touch.position)) {
				Debug.Log ("hit");
			}
		}

	}
}
