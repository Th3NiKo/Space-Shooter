using UnityEngine;
using System.Collections;

public class miniUfo : MonoBehaviour {

	public GameObject player;
	public GameObject particles;

	Rigidbody2D rgb;
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, GameObject.Find("Player").GetComponent<Rigidbody2D>().position, .12f);
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
		}
		if (other.gameObject.tag == "Bullet") {
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
		}

	}
}
