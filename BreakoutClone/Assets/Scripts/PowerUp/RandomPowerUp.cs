using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUp : InstantPowerUp {

	public PowerUp[] powerUps;

	protected override void Apply()
	{
		PowerUpHolder.Instance.Add(powerUps[Random.Range(0, powerUps.Length)]);
	}
}
