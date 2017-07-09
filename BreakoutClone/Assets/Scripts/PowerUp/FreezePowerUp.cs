using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerUp : TimedPowerUp 
{
	private PlatformController controller;

	protected override void PowerUpStart()
	{
		controller = StageManager.Instance.platform.GetComponent<PlatformController>();
        controller.enabled = false;
	}

	protected override void PowerUpEnd()
	{
		controller.enabled = true;
	}
}
