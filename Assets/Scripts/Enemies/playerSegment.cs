using UnityEngine;
using System.Collections;

public class playerSegment : MonoBehaviour {

	public GameObject player;
	public GameObject particles;
	Rigidbody2D rgb;
	


	float x;
	float y;
	void Start () {
		rgb = GetComponent < Rigidbody2D >();
		player = GameObject.Find ("Player");
	}
	

	void Update () {
		rgb.velocity = new Vector2 (-10.0f, 0);
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "CloudDestroy") {
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
		}
	}

};