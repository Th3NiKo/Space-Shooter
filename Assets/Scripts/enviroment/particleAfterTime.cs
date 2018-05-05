using UnityEngine;
using System.Collections;

public class particleAfterTime : MonoBehaviour {


	void Start () {
		Invoke ("deleteParticles", 5);
	}
	

	void Update () {
	
	}

	void deleteParticles()
	{
		Destroy (this.gameObject);
	}
}
