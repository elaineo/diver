using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			StartCoroutine(Transition());
			//Application.LoadLevel("scene");
		}
	}

	IEnumerator Transition() {
		Debug.Log ("Transition");
		for (float i = 0.0f; i < 1.0f; i+= 0.01f) {
			transform.Translate(new Vector3(0.0f, 0.1f, 0.0f));			
			transform.localScale += new Vector3(0.0f, 0.1f, 0.0f);
			yield return null;
		}
		Application.LoadLevel("scene");
	}
}
