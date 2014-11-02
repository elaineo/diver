using UnityEngine;
using System.Collections;

public class OxygenBubble : MonoBehaviour {
	public float acceleration = 0.1f;
	public float velocity = 0.0f;
	public AudioClip popClip;	
	Vector3 startScale;
	float startTime;
	bool popped = false;
	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
	}
	
	void FixedUpdate () {
		// Check bounds
		Vector3 pos = transform.position;
		Vector3 camxy = Camera.main.WorldToScreenPoint(pos);		
		if (camxy.x < 0) {
			Destroy (this.gameObject);
		} 
		else if (camxy.y > Screen.height) {
			Destroy (this.gameObject);
		}
		else {
			// Euler integration for performance
			velocity += Time.deltaTime * acceleration;
			pos.y += velocity * Time.deltaTime;
			transform.position = pos;
		}
	}

	void Update() {
		if (!popped) {
			startTime += Time.deltaTime;
			float scale = 0.1f * Mathf.Sin (6.0f * startTime);
			transform.localScale = new Vector3 (startScale.x + scale, startScale.y + scale, startScale.z);
		}
	}
	
	IEnumerator FadeAndDestroy() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			transform.localScale += new Vector3(0.05f, 0.05f, 0);
			
			yield return null;
		}
		
		Destroy (this.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			//Score.AddCoin();
			OxygenBar.addOxygen(0.25f);
			//Destroy (this.gameObject);
			popped = true;
			AudioSource.PlayClipAtPoint(popClip, transform.position);
			StartCoroutine("FadeAndDestroy");
		}
	}
}
