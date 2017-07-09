using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickNormal : Brick {
	public int score;

	protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            DestroyBrick();
        }
    }
	
	protected override void DestroyBrick()
	{
		GameManager.Instance.CurrentGame.Score += score;
        StageManager.Instance.DecreaseBrick();

        Destroy(gameObject);
	}
}
