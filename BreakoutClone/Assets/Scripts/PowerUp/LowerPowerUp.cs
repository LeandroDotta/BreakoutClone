using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPowerUp : InstantPowerUp 
{
	protected override void Apply()
	{
		StageManager.Instance.platform.Lower();
	}
}
