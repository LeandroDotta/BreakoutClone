using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
    public Ball ball;
    public Platform platform;

    [Header("UI Elements")]
    public Text textLifeCount;
    public Text textScore;

    private int brickCount;

    public static StageManager Instance { get; set; }
    public bool IsFirstLaunch { get; set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;

        SetScoreText(GameManager.Instance.CurrentGame.Score);
        SetLifeCountText(GameManager.Instance.CurrentGame.LifeCount);

        Cursor.visible = false;
    }

    public void ResetBall()
    {
        platform.ResetPosition();
        ball.ResetPosition();

        IsFirstLaunch = true;
    }

    public void SetScoreText(int score)
    {
        if(textScore != null)
            textScore.text = score.ToString();
    }

    public void SetLifeCountText(int lifeCount)
    {
        if(textLifeCount != null)
            textLifeCount.text = lifeCount.ToString();

        if(lifeCount <= 0)
            GameManager.Instance.GameOver();
    }

    public void DecreaseBrick()
    {
        brickCount--;

        if(brickCount <= 0)
            GameManager.Instance.GameOver();
    }

    void OnDestroy()
    {
        Cursor.visible = true;
    }
}
