using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPowerUp : InstantPowerUp 
{
	protected override void Apply()
	{
		StageManager.Instance.platform.GrowUp();
	}
}
