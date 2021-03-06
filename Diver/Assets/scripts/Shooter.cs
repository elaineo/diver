using UnityEngine;
using System.Collections;

//This script is the base for any enemy that shoots
//Ensure that the game object this is on has a rigidbody and animator
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Shooter : MonoBehaviour
{
	public float speed;						//Ship's speed
	public float shotDelay;					//Delay between shots
	public float moveSpeed = 0.5f;		// The speed the enemy moves at.	
	public GameObject bullet;				//The prefab of this ship's bullet
	public bool canShoot;					//Can this ship fire?
	public GameObject explosion;			//The prefab of this ship's explosion

	protected Transform[] shotPositions;	//Fire points on the shooter
	protected Animator animator;			//Reference to the ship's animator component


	void Awake ()
	{
		//Get the fire points for future reference (this is for efficiency)
		shotPositions = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
			shotPositions[i] = transform.GetChild (i);
		//Get a reference to the animator component
		animator = GetComponent<Animator> ();
	}

	protected virtual void OnEnable()
	{		
		//If the game is playing and the ship can shoot...
		if (canShoot)
			//...Start it shooting
			StartCoroutine ("Shoot");
	}

	void OnDisable()
	{
		//If the ship was able to shoot and it became disabled...
		if(canShoot)
			//...Stop shooting
			StopCoroutine ("Shoot");
	}

	protected void Explode ()
	{
		//instantiate an explosion
	}

	void FixedUpdate ()
	{

		// Set the enemy's velocity to moveSpeed in the x direction.
		rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	

		Vector3 pos = transform.position;
		Vector3 camxy = Camera.main.WorldToScreenPoint(pos);		
		if (camxy.x < -Screen.width)
			Destroy(this.gameObject);
	}

	//Coroutine
	IEnumerator Shoot ()
	{
		//Loop indefinitely
		while(true)
		{
			//If there is an acompanying audio, play it
			if (audio)
				audio.Play ();
			//Loop through the fire points
			for(int i = 0; i < shotPositions.Length; i++)
			{
				// create a bullet
				//bullet.transform.rotation = Quaternion.Euler(0, 0, 90.0f);
				Instantiate(bullet, shotPositions[i].position, shotPositions[i].rotation  );
				//Activate it
				//obj.SetActive(true);
				//Debug.Log(obj);
			}
			//Wait for it to be time to fire another shot
			yield return new WaitForSeconds(shotDelay);
		}
	}
}