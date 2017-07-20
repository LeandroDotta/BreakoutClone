using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPowerUp : InstantPowerUp 
{
	protected override void Apply()
	{
		PowerUpHolder.Instance.Clear();
	}
}
