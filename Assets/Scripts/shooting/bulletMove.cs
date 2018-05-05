using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {

	public GameObject particles;
	Rigidbody2D rgb;

	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		rgb.velocity = new Vector2 (15.0f, 0);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		switch (other.gameObject.tag) {

		case "Enemy":
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
			Destroy (this.gameObject);
			Destroy (other.gameObject);
			playerMovement.countPlus (10);
			break;
		case "CloudDestroy":
			Destroy (this.gameObject);
			break;
		case "Enemy1":
			Destroy (this.gameObject);
			break;


		}

	}
}
