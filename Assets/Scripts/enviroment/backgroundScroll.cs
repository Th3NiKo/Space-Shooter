using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour {

	float speed;

	void Start () {
		speed = 2f;
	}
	

	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
