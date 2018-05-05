using UnityEngine;
using System.Collections;

public class enemy2 : MonoBehaviour {

	Rigidbody2D rgb;
	public GameObject particles;


	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreLayerCollision (9, 9);
	}
	

	void Update () {
		move ();
	}

	void move()
	{
		rgb.velocity = new Vector2(-10.0f, 0);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
		}
		if (other.gameObject.tag == "CloudDestroy") {
			Destroy (this.gameObject);
		}
	}
}
