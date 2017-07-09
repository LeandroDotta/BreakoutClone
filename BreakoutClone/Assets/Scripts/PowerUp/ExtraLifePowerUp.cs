using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : InstantPowerUp
{
	protected override void Apply()
	{
		GameManager.Instance.CurrentGame.LifeCount++;
	}
}
