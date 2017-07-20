using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPowerUp : TimedPowerUp {

	private Animator barrierAnim;

	protected override void PowerUpStart()
	{
		barrierAnim = StageManager.Instance.Barrier.GetComponent<Animator>();
		barrierAnim.SetTrigger("fadeIn");
	}

	protected override void PowerUpEnd()
	{
		barrierAnim.SetTrigger("fadeOut");
	}
}
