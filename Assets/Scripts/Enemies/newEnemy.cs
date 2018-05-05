using UnityEngine;
using System.Collections;

public class newEnemy : mainEnemy {



	void Start () {
		setVariables(3, 0.7f, 6f, 1.1f, 15);
	}
	

	void Update () {
		healthControl ();
		flyHorizontaly (0);
	}
}
