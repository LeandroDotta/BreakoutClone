using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
	public enum PowerUpType
	{
		Neutral,
		Bonus,
		Penalty
	}

	public PowerUpType type;

	//protected abstract void Start();
	protected abstract void Apply();
}
