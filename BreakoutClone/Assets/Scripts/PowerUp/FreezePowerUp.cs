using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerUp : TimedPowerUp 
{
	private Platform platform;

	protected override void PowerUpStart()
	{
		platform = StageManager.Instance.platform.GetComponent<Platform>();
        platform.IsFrozen = true;
	}

	protected override void PowerUpEnd()
	{
		platform.IsFrozen = false;
	}
}
