using UnityEngine;

//This script will handle the bullet adding itself back to the pool
public class Bullet : MonoBehaviour
{
	public int speed = 10;			//How fast the bullet moves
	public float lifeTime = 1;		//How long the bullet lives in seconds
	public int power = 1;			//Power of the bullet


	void OnCollisionEnter2D(Collision2D collision) {		
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag== "Bullet") {
			// also check if block
			Debug.Log ("Bullet shot : " + collision.gameObject.tag);
//			rigidbody2D.simulated = false;
//			Destroy(this.gameObject);
		}

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