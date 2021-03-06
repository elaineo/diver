﻿using UnityEngine;

//This script will handle the bullet adding itself back to the pool
public class Bullet : MonoBehaviour
{
	public int speed = 3;			//How fast the bullet moves
	public float lifeTime = 1;		//How long the bullet lives in seconds
	public int power = 10;			//Power of the bullet


	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("bullet hit :" + collision.gameObject.tag);
		//Destroy(this.gameObject);
		if (collision.gameObject.tag=="Enemy" || collision.gameObject.tag=="Player" || collision.gameObject.tag=="blockset" ||  collision.gameObject.tag=="Sky" ||  collision.gameObject.tag=="Sand")
			Destroy(this.gameObject);

	}

	void OnEnable ()
	{
		//Send the bullet "forward"
		rigidbody2D.velocity = transform.up.normalized * speed;
		//Invoke the Die method
		Invoke ("Die", lifeTime);
	}

	void OnDisable()
	{
		//Stop the Die method (in case something else put this bullet back in the pool)
		CancelInvoke ("Die");
	}

	void Die()
	{
		//Add the bullet back to the pool
		//ObjectPool.current.PoolObject (gameObject);
		Destroy(this.gameObject);
	}
}