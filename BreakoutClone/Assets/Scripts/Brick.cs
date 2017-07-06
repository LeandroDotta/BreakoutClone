using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public int score;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            DestroyBrick();
        }
    }

    protected void DestroyBrick()
    {
        GameManager.Instance.CurrentGame.Score += score;
        StageManager.Instance.SetScoreText(GameManager.Instance.CurrentGame.Score);
        StageManager.Instance.DecreaseBrick();

        Destroy(gameObject);
    }
}
