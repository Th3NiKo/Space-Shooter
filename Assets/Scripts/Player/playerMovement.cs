using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

	static int count;
	int gold;
	public GameObject coin;
	public GameObject segment;
	public GameObject bullet;
	public GameObject hearth;
	float speed;
	Rigidbody2D rgb;
	float shootSpeed;
	float shootTime;
	float shootTimer;
	public shooting_style shootStyle;

	public enum shooting_style{
		normal = 0,
		doubleShoot = 1,
		tripleShoot = 2,
		quadraShoot = 3,
		laser = 4
	}

	int health;
	public Text healthText;
	public Image healthImage;
	public Text pointsText;




	void Start () {
		health = 3;
		shootTimer = 0;
		shootSpeed = 0.3f;
		gold = 0;
		count = 0;
		speed = 10.0F;
		//shootStyle = shooting_style.normal;
		rgb = GetComponent<Rigidbody2D> ();
		healthImage.fillAmount = 0;
		pointsText = pointsText.GetComponent<Text> ();
	}


	void Update () {
		//TIMERS
		shootTimer += Time.deltaTime;


		//REST
		float move = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		float move2 =  Mathf.Clamp(Input.GetAxis ("Vertical") * Time.deltaTime * speed,-8.75f ,3.24f) ;

		transform.Translate (new Vector2 (move,Mathf.Clamp( move2,-4.0f ,4.0f )));
		transform.position = new Vector2(Mathf.Clamp(transform.position.x,-8.75f ,3.24f),Mathf.Clamp(transform.position.y,-4.0f ,4.0f)); 
		shoot ();
		lifeControl ();
		pointsControl ();

	}

	public static void countPlus(int points)
	{
		count = count + points;
	}

	public static int getCount()
	{
		return count;
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		
		if (target.gameObject.tag == "Gold") {
			Debug.Log ("done");
			Destroy (target.gameObject);
			gold++;
			Instantiate(coin, new Vector2(Random.Range(-7.5f,7.5f), Random.Range(-2.5f, 2.5f)), Quaternion.identity);
		}

		if (target.gameObject.tag == "Enemy") {
			healthImage.fillAmount += 0.333333f;
			damageColor ();
			health--;
		}

		if (target.gameObject.tag == "Health") {
			Destroy (target.gameObject);
			if (health < 3) {
				healthImage.fillAmount -= 0.333333f;
				health++;
			}
		}

		if (target.gameObject.tag == "BulletEnemy") {
			healthImage.fillAmount += 0.333333f;
			damageColor ();
			health--;
		}
			
	}

	public float getX()
	{
		return transform.position.x;
	}

	public float getY()
	{
		return transform.position.y;
	}


	void shoot()
	{
		
			if (Input.GetKey ("space")) 
			{
				if (shootTimer > shootSpeed) 
				{
					shootTimer = 0;
					switch(shootStyle)
					{
						case shooting_style.normal: 
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y), Quaternion.identity);
						break;

						case shooting_style.doubleShoot:
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y - 0.2f), Quaternion.identity);
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y + 0.2f), Quaternion.identity);
						break;

						case shooting_style.tripleShoot:
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y - 0.25f), Quaternion.identity);
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y ), Quaternion.identity);
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y + 0.25f), Quaternion.identity);
						break;

						case shooting_style.quadraShoot:
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y - 0.60f), Quaternion.identity);
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y - 0.20f), Quaternion.identity);
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y + 0.20f), Quaternion.identity);
						Instantiate (bullet, new Vector2 (rgb.position.x + 1.4f, rgb.position.y + 0.60f), Quaternion.identity);
						break;
					}
				}
			}
	}




	void lifeControl()
	{
		if (health <= 0) {
			Time.timeScale = 0.1f;
			Invoke ("restartLevel", 0.4f);
			}
	}

	void restartLevel()
	{
		SceneManager.LoadScene ("level1");
		Time.timeScale = 1;
	}


	void pointsControl()
	{
		pointsText.text = count.ToString();
	}

	void damageColor()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
		Invoke ("changeColor", 0.2f);
	}

	void changeColor() //Changing color to normal
	{
		GetComponent<SpriteRenderer> ().color = Color.white;
	}


}
