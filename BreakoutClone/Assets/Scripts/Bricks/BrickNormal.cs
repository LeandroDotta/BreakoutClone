using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickNormal : Brick {
	public int score;
    public PowerUpApplier powerUp;

	protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            DestroyBrick();
        }
    }
	
	protected override void DestroyBrick()
	{
        StageManager.Instance.AddScore(score);		
        StageManager.Instance.DecreaseBrick();

        if(powerUp != null)
        {
            GameObject powerUpInstance = Instantiate(powerUp.gameObject);
            powerUpInstance.transform.position = transform.position;
            powerUpInstance.name = powerUp.name;
            powerUpInstance.SetActive(true);
        }

        Destroy(gameObject);
	}

    private void OnDrawGizmos()
    {
        if(powerUp != null){
            Gizmos.DrawIcon(transform.position, powerUp.powerUpPrefab.name + ".png", false);
        }
    }
}
