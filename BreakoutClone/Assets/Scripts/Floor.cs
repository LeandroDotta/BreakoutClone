using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ball"))
        {
            GameManager.Instance.CurrentGame.LifeCount--;

            AudioManager.Instance.Play(AudioManager.Instance.sfxLoseLife);

            StageManager.Instance.ResetBall();
        }
    }
}
