using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 50f;
	public float forwardSpeed = 2f;
	public GameObject powerUp;

	bool didFlap = false;

	Animator animator;

	public bool dead = false;
	float deathCooldown;

	public AudioClip swimClip;	
	public bool godMode = true;
	public bool skyOxygenRefill = false;	


	private float dragCoefficient= 0.5f;
	private float buoyancyCoefficient= 0.2f;		
	private float startGravity= 0.6f;

	bool poweredUp = false;
	float invincibilityTimeout = 2.0f;
	float powerUpTimeout = 5.0f;	
	bool invicible = false;

	private ParticleSystem bubbles;
	public static Player currentPlayer;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}

		bubbles = gameObject.GetComponentInChildren<ParticleSystem>();
		currentPlayer = this;
	}

	// Do Graphic & Input updates here
	void Update() {
		if(dead) {			
			deathCooldown -= Time.deltaTime;
			if(deathCooldown <= 0) {
				Application.LoadLevel("title");
			}
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
				//Debug.Log(swimClip.isPlaying);
				// if (!swimClip.isPlaying)
				AudioSource.PlayClipAtPoint(swimClip, transform.position);
				bubbles.Play();
			}

			if (invincibilityTimeout > 0.0f) {
				invincibilityTimeout -= Time.deltaTime;
			}
			else if (invicible) {
				invicible = false;
				SpriteRenderer r = gameObject.GetComponentInChildren<SpriteRenderer>();
				Color c = r.color;
				c.a = 1.0f;
				r.material.color = c;
			}
			if (powerUpTimeout > 0.0f) {
				powerUpTimeout -= Time.deltaTime;
			}
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

		if(dead)
			return;

		if (OxygenBar.Oxygen () <= 0.0f) {
			die ();
			return;
		}

		rigidbody2D.AddForce( Vector2.right * forwardSpeed );


		if(didFlap) {
			rigidbody2D.AddForce( Vector2.up * flapSpeed );
			animator.SetTrigger("DoFlap");
			didFlap = false;
		}

		if(rigidbody2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			float angle = Mathf.Lerp (0, -90, (-rigidbody2D.velocity.y / 6f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		rigidbody2D.drag = rigidbody2D.velocity.magnitude * dragCoefficient;
		//rigidbody2D.gravityScale = (buoyancyCoefficient - rigidbody2D.position.y) * startGravity+0.2f;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "PlayerBullet(Clone)") {
		  	// push it 
		  	Debug.Log ("player Got shot: " + collider.attachedRigidbody.velocity);
		  	rigidbody2D.AddForce(collider.attachedRigidbody.velocity);		
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		// Sky is not a death condition
		if (collision.gameObject.tag == "Sky") {
			// Refill oxygen
			if (skyOxygenRefill)
				OxygenBar.addOxygen();
			return;
		}

		// Check death conditions
		if (godMode)
			return;

		if (poweredUp) {
			poweredUp = false;
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);			
			SpriteRenderer r = gameObject.GetComponentInChildren<SpriteRenderer>();
			Color c = r.color;
			c.a = 0.3f;
			r.material.color = c;
			//invincibilityTimeout = 2.0f;
			//invicible = true;
			powerUpTimeout = 5.0f;
		}

		if (invicible)
			return;

		die ();
	}

	void die() {
		Debug.Log ("Player Died");
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 1.0f;
		rigidbody2D.gravityScale = -buoyancyCoefficient;
	}

	public void PowerUp() {
		if (poweredUp)
			return;
		poweredUp = true;
		transform.localScale -= new Vector3 (0.5f, 0.5f, 0.5f);
	}
}
