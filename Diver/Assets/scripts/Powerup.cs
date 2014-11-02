using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	public float lifespan = 2;
	bool fading;
	float startTime;

	// Use this for initialization
	public void Start () {
		fading = false;
		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0 && !fading) {
			StartCoroutine("FadeAndDestroy");
			fading = true;
		}
		
		float deltaTime = Time.realtimeSinceStartup - startTime;
		float yDelta = 0.6f + 0.8f * Mathf.Sin (deltaTime * 2.0f);
		Vector3 pos = transform.position;
		pos.x += -1.0f * Time.deltaTime;
		pos.y = yDelta;
		transform.position = pos;
	}

	IEnumerator FadeAndDestroy() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			transform.localScale += new Vector3(0.1f, 0.1f, 0);
			yield return null;
		}
		
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {	
			Player player = collider.gameObject.GetComponent<Player>();
			player.PowerUp();
			StartCoroutine("FadeAndDestroy");
		}
	}
}
