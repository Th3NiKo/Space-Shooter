using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject ufoBoss;
	bool isUfoBoss;
	private float timer;
	private float timer1;
	private float timer2;

	void Start () {
		isUfoBoss = false;
		timer = 0;
		timer1 = 0;
		timer2 = 0;
	}


	void Update () {

		timer += Time.deltaTime;
		timer1 += Time.deltaTime;
		timer2 += Time.deltaTime;
		if (playerMovement.getCount () >= 500) {
			if (isUfoBoss == false) {
				Instantiate (ufoBoss, new Vector2 (enemy.transform.position.x + 2.0f, 2.0f), Quaternion.identity);
				isUfoBoss = true;
			}
		} else {
			if (timer >= 2) {
				timer = 0;
				spawnEnemy ();
			}
			spawnEnemy1 ();
			spawnEnemyGroup (enemy2);
		}

	}

	void spawnEnemy() //Mini rocket
	{
		float y = Random.Range (-3.8f, 3.8f);
		Instantiate (enemy, new Vector3 (enemy.transform.position.x, y, enemy.transform.position.z), Quaternion.identity);
	}

	void spawnEnemy1() //Big one (shooting)
	{
		if (timer1 >= 0.5f) {
			timer1 = 0;
			int x = Random.Range (1, 100);
			if (x > 96) {
				float y = Random.Range (-3.8f, 3.8f);
				Instantiate (enemy1, new Vector2 (enemy.transform.position.x, y), Quaternion.identity);
			}
		}
	}

	void spawnEnemyGroup(GameObject enemyMain)//Small one (gruoping)
	{
		if (timer2 >= 0.70f) {
			timer2 = 0;
			int x = Random.Range (1, 100);
			if (x > 90) {
				float y = Random.Range (-3.8f, 3.8f);
				int amount = Random.Range (1, 5);
				switch (amount) {
				case 1:
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y), Quaternion.identity);
					break;
				case 2:
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y - 0.75f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y + 0.75f), Quaternion.identity);
					break;
				case 3:
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y - 1.0f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y + 1.0f), Quaternion.identity);
					break;
				case 4:
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y - 1.0f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y ), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y + 1.0f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x - 1.15f, y), Quaternion.identity);
					break;
				case 5:
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y - 1.0f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y ), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x, y + 1.0f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x - 1.15f, y - 0.75f), Quaternion.identity);
					Instantiate (enemyMain, new Vector2 (enemy.transform.position.x - 1.15f, y + 0.75f), Quaternion.identity);
					break;

				}
			}

		}

	}

}
