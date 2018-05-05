using UnityEngine;
using System.Collections;

public class enemy1 : MonoBehaviour {

	Rigidbody2D rgb;
	float speed = 3.0f;
	float speedV = 0.7f	;
	float timer;
	float shootTimer;
	public GameObject otherEnemy;
	public GameObject particles;
	public GameObject bullet;
	float health;

	void Start () 
	{
		health = 5;
		rgb = GetComponent<Rigidbody2D> ();
		timer = 0;
		shootTimer = 0;
		Physics2D.IgnoreLayerCollision (9,9);  //Ignoring collision Enemy - Enemy
	}
	

	void Update () 
	{
		shootTimer += Time.deltaTime;
		timer += Time.deltaTime;
		flyForward ();
		Invoke ("flyVertical", 2);
		healthControl ();
		shoot ();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			GetComponent<SpriteRenderer>().color = Color.red;
			Invoke ("changeColor", 0.2f);
			health--;
		}
	}

	void flyForward() //Flying forward
	{
		if (transform.position.x >= 2.0f) {
			rgb.velocity = new Vector2 (-speed, 0);
		}
	}

	void flyVertical() //Flying verticaly
	{
		if (timer > 2) {
			timer = 0;
			speedV = speedV * (-1);
			rgb.velocity = new Vector2 (0, speedV);
		}
	}

	void healthControl() //Checking if player is still alive
	{
		if (health <= 0) {
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
			playerMovement.countPlus (50);
		}
	}

	void changeColor() //Changing color to normal
	{
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void shoot() //Randomly shooting 
	{
		if (shootTimer >= 0.5f) {
			shootTimer = 0;
			float x = Random.Range (1, 100);
			if (x > 85) {
				Instantiate (bullet, new Vector2 (rgb.position.x - 1.5f, rgb.position.y), Quaternion.identity);
			}
		}
	}
}
