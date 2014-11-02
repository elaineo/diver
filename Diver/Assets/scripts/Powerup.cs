using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	public float lifespan = 2;
	bool fading;

	// Use this for initialization
	public void Start () {
		fading = false;
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0 && !fading) {
			StartCoroutine("FadeAndDestroy");
			fading = true;
		}

		transform.Translate (-1.0f * Time.deltaTime, 0, 0);
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
