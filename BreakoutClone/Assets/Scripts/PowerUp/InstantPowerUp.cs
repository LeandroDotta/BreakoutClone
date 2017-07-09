using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantPowerUp : PowerUp {

	// Use this for initialization
	protected void Start () {
		Apply();
		Destroy(gameObject);
	}
}
