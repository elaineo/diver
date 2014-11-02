using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour {
	public float UpwardForce = 120.0f;
	//public GameObject SplashParticles;
	private bool isInWater = false;
	private bool splash = false;
	private BoxCollider2D water;
	void OnTriggerEnter2D(Collider2D Other){
		if (Other.tag == "Water") {
			isInWater = true;
			rigidbody2D.drag = 2f;
			rigidbody2D.angularDrag = 2f;
			water = (BoxCollider2D)Other;
		}
//		if (Other.tag == "Water" && !splash){
//			Instantiate(SplashParticles, transform.position, Quaternion.identity);
//			splash = true;
//		}
		
	}
	
	void OnTriggerExit2D(Collider2D Other){
		if (Other.tag == "Water"){
			isInWater = false;
			rigidbody2D.drag = 0.5f;
			rigidbody2D.angularDrag = 0.5f;
			water = null;
		}
	}
	
	void FixedUpdate(){
		if (isInWater){
			Vector2 force = Vector2.up * UpwardForce;
			BoxCollider2D col = (BoxCollider2D)collider2D;
			float intersectionY = Mathf.Min(Mathf.Max(water.bounds.max.y - col.bounds.min.y, 0), col.bounds.size.y);
			Debug.Log ("Intersection: " + intersectionY.ToString());
			float percentage = (intersectionY / col.size.y);
			this.rigidbody2D.AddForce(force * percentage * rigidbody2D.mass, ForceMode2D.Force);
			Debug.Log(isInWater);
		}
	}
}