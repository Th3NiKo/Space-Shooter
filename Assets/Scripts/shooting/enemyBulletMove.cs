using UnityEngine;
using System.Collections;

public class enemyBulletMove : MonoBehaviour {

	Rigidbody2D rgb;

	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreLayerCollision (10, 10);
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
		switch (other.gameObject.tag) {
		case "CloudDestroy":
			Destroy (this.gameObject);
			break;
		case "Player":
			Destroy (this.gameObject);
			break;

		}

	}
}
