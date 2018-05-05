using UnityEngine;
using System.Collections;

public class mainEnemy : MonoBehaviour {

	//VARIABLES
	int health;
	float speedV;
	float speedH;
	float timerShooting;
	float timerFlyingLoop;
	float shootRate;
	int points;
	Rigidbody2D rgb;


		


	public void setVariables(int h, float sV, float sH, float sRate, int p)
	{
		health = h;
		speedV = sV;
		speedH = sH;
		shootRate = sRate;
		points = p;
		rgb = GetComponent<Rigidbody2D> ();
		timerShooting = 0;
		timerFlyingLoop = 0;
	}

	void Start () {
	
	}
	

	void Update () {
		timerShooting += Time.deltaTime;
		timerFlyingLoop += Time.deltaTime;
	}


	public void flyHorizontaly(int direction){ // DIRECTIONS:  0 - left , 1 - right
		if (direction == 0) {
			rgb.velocity = new Vector2 (-speedH, 0);
		} else if (direction == 1) {
			rgb.velocity = new Vector2 (speedH, 0);
		} else {
			Debug.Log ("Wrong set of Enemy fly direction Horizontal");
		}
	}
		
	public void flyVerticaly(int direction){ // DIRECTIONS:  0 - up , 1 - down
		if (direction == 0) {
			rgb.velocity = new Vector2 (0, speedV);
		} else if (direction == 1) {
			rgb.velocity = new Vector2 (0, -speedV);
		} else {
			Debug.Log ("Wrong set of Enemy fly direction Vertical");
		}
	}

	public void flyLoop(float flyTime){
		if (timerFlyingLoop >= flyTime) {
			timerFlyingLoop = 0;
			speedV = speedV * (-1);
			rgb.velocity = new Vector2 (0, speedV);
		}

	}

	public void healthControl()
	{
		if (health <= 0) {
			playerMovement.countPlus (points);
			Destroy (this.gameObject);
		}
	}

	public void healthControl(GameObject particles)
	{
		if (health <= 0) {
			playerMovement.countPlus (points);
			Destroy (this.gameObject);
			Instantiate (particles, new Vector2 (rgb.position.x, rgb.position.y), Quaternion.identity);
		}
	}

	public void shoot(GameObject bullet, float bPosX, float bPosY) 
	{
		if (timerShooting >= shootRate) {
			timerShooting = 0;
			Instantiate (bullet, new Vector2 (rgb.position.x + bPosX, rgb.position.y + bPosY), Quaternion.identity);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
		if (other.gameObject.tag == "Bullet") {
			health--;
			Destroy (other.gameObject);
		}
	}


	//****************************************************************************************
	//									GETERS & SETTERS
	//****************************************************************************************

	public int getHealth(){
		return health;
	}

	public float getSpeedV(){
		return speedV;
	}

	public float getSpeedH(){
		return speedH;
	}

	public float getShootRate(){
		return shootRate;
	}

	public void setHealth(int h){
		health = h;
	}

	public void setSpeedV(float sV)
	{
		speedV = sV;
	}

	public void setSpeedH(float sH)
	{
		speedH = sH;
	}

	public void setShootRate(float sRate)
	{
		shootRate = sRate;
	}









}
