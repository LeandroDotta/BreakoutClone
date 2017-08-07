using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPowerUp : TimedPowerUp 
{
	public float speed;

	private Ball ball;
	private float ballDefaultSpeed;

	new void Start()
	{
		PowerUpHolder.Instance.Remove<SlowPowerUp>();

		base.Start();
	}

	protected override void PowerUpStart()
	{
		ball = StageManager.Instance.ball.GetComponent<Ball>();
        ballDefaultSpeed = ball.Movement.speed;
		ball.Movement.SetSpeed(speed);
	}

	protected override void PowerUpEnd()
	{
		ball.Movement.SetSpeed(ballDefaultSpeed);
	}
}

