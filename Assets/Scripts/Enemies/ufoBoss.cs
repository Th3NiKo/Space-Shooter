using UnityEngine;
using System.Collections;

public class ufoBoss : MonoBehaviour {

	Rigidbody2D rgb;
	Animator animator;
	public GameObject bullet;
	public GameObject miniUfo;
	public GameObject particles;

	float speed = 15.0f;
	float speedV = 3.0f;
	float timer;
	float stateTimer;
	float shootTimer;
	float ufoSummonTimer;

	bool summoned;

	state ufoState;
	int health = 60;

	public enum state{
		normal = 0,
		shooting = 1,
		summoning = 2
	}


	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		summoned = false;
		timer = 0;
		stateTimer = 0;
		shootTimer = 0;
		ufoSummonTimer = 0;
		ufoState = state.normal;
	}
	

	void Update () {
		//MAIN
		timer += Time.deltaTime;
		stateTimer += Time.deltaTime;
		shootTimer += Time.deltaTime;
		ufoSummonTimer += Time.deltaTime;
		healthControl ();
		stateControl ();


		//STATES
		switch(ufoState)
		{
		case state.normal:
			animator.SetInteger ("State", 0); // SETTING ANIMATION
			flyForward ();
			flyVertical ();
			break;
		case state.shooting:
			animator.SetInteger ("State", 1); // SETTING ANIMATION
			flyVertical ();
			Invoke("shoot", 1.0f);
			break;
		case state.summoning:
			
			rgb.velocity = new Vector2 (0, 0);
			animator.SetInteger ("State", 2); // SETTING ANIMATION
			if (summoned == false) {
				Invoke ("summonUfo", 1.5f);
				Invoke ("summonUfo", 2.5f);
				summoned = true;
			}
			break;

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
		if (timer > 0.5f) {
			if (transform.position.x <= 2.0f) {
				timer = 0;
				speedV = speedV * (-1);
				rgb.velocity = new Vector2 (0, speedV);
			}
		}
	}

	void changeColor() //Changing color to normal
	{
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void healthControl() //Checking if player is still alive
	{
		if (health <= 0) {
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
			playerMovement.countPlus (750);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Bullet") {
			GetComponent<SpriteRenderer>().color = Color.red;
			Invoke ("changeColor", 0.2f);
			health--;
		}
	}

	void stateControl() //Changing and randomize states
	{
		if (stateTimer >= 4) {
			summoned = false;
			stateTimer = 0;
			int tempState = Random.Range (0, 3);
			Debug.Log (tempState);
			if (tempState == 0) {
				ufoState = state.normal;
				stateTimer = 2.5f;
			}
			if (tempState == 1)
				ufoState = state.shooting;
			if (tempState == 2)
				ufoState = state.summoning;
		}
	}

	void shoot()
	{
		if (shootTimer >= 0.5) {
			shootTimer = 0;
			int temp = Random.Range (1, 2);
			if (temp == 1) {
					Instantiate (bullet, new Vector2 (rgb.position.x - 3.0f, rgb.position.y + -1.0f), Quaternion.identity);
				}
			}
	}

	void summonUfo()
	{
		Instantiate (miniUfo, new Vector2 (rgb.position.x, rgb.position.y - 2.5f), Quaternion.identity);
	}


}
