using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPowerUp : TimedPowerUp 
{	
	protected override void PowerUpStart()
	{
		StageManager.Instance.platform.IsSticky = true;
	}

	protected override void PowerUpEnd()
	{
		StageManager.Instance.platform.IsSticky = false;

		if(StageManager.Instance.ball.IsLocked)
			StageManager.Instance.ball.Launch();
	}
}