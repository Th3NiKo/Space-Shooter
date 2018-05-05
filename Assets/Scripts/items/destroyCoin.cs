using UnityEngine;
using System.Collections;

public class destroyCoin : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
		
	
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.name == "Player") {
			Destroy(this.gameObject);
		
		}
	}
};