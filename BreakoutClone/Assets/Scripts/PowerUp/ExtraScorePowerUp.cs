﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraScorePowerUp : InstantPowerUp 
{
	public int score;

	protected override void Apply()
	{
		GameManager.Instance.CurrentGame.Score += score;
	}
}
