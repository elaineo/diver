using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 50f;
	public float forwardSpeed = 1f;

	bool didFlap = false;

	Animator animator;

	public bool dead = false;
	float deathCooldown;

	public bool godMode = true;

	private float dragCoefficient= 2.5f;
	private float buoyancyCoefficient= 2.2f;	
	private float startGravity= 0.6f;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}

	// Do Graphic & Input updates here
	void Update() {
		if(dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0) {
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
					Application.LoadLevel( Application.loadedLevel );
				}
			}
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
			}
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

		if(dead)
			return;

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
		rigidbody2D.gravityScale = (buoyancyCoefficient - rigidbody2D.position.y) * startGravity;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode)
			return;

		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
}
