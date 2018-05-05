using UnityEngine;
using System.Collections;

public class itemMove : MonoBehaviour {

	Rigidbody2D rgb;
	float timer;
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		timer = 0;
	}

	

	void Update () {
		timer += Time.deltaTime;
		move ();
	}

	void move()
	{
		if (timer <=0.8) {
			rgb.velocity = new Vector2 (-7.0f, 3.0f);
		} else {
			
			rgb.velocity = new Vector2 (-7.0f, -3.0f);
			if (timer >= 1.6f) {
				timer = 0;
			}
		}
			
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy")
			{
				Destroy(this.gameObject);
			}

	}
}
