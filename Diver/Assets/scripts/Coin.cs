using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public AudioClip coinClip;	

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		Vector3 pos = transform.position;
		Vector3 camxy = Camera.main.WorldToScreenPoint(pos);		
		if (camxy.x < 0)
			Destroy(this.gameObject);
	}

	IEnumerator FadeAndDestroy() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;

			Vector3 pos = transform.position;
			pos.y += 0.05f;
			transform.position = pos;

			yield return null;
		}
		
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			Score.AddCoin();
			AudioSource.PlayClipAtPoint(coinClip, transform.position);
			//Destroy (this.gameObject);
			StartCoroutine("FadeAndDestroy");
		}
	}
}
