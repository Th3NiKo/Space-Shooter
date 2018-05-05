using UnityEngine;
using System.Collections;

public class itemSpawner : MonoBehaviour {

	public GameObject health;
	float healthTimer;
	void Start () {
		healthTimer = 0;
	}
	

	void Update () {
		healthTimer += Time.deltaTime;
		if (healthTimer > 1.0f) {
			healthTimer = 0;
			if (Random.Range (1, 100) >= 97) {
				Instantiate (health, new Vector2 (transform.position.x - 1.0f,Random.Range(-3.0f, 3.0f)), Quaternion.identity);
			}
		}

	}
}
