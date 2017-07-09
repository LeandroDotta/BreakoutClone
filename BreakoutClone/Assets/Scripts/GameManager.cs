using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game
{
    private int _score;
    private int _lifeCount;

    public int Score { 
        get
        {
            return _score;
        }
        set
        {
            _score = value;

            if(StageManager.Instance != null)
                StageManager.Instance.SetScoreText(value);
        }
    }
    public int LifeCount { 
        get
        {
            return _lifeCount;
        }
        set
        {
            _lifeCount = value;

            if(StageManager.Instance != null)
                StageManager.Instance.SetLifeCountText(value);
        } 
    }

    public Game(int lifeCount)
    {
        LifeCount = lifeCount;
    }
}

public class GameManager : MonoBehaviour {
    public int lifes;

    public static GameManager Instance { get; set; }

    
    public Game CurrentGame { get; set; }

    public string PlayersName
    {
        get
        {
            return PlayerPrefs.GetString("PlayersName", "Dr. Breakout");
        }
        set
        {
            PlayerPrefs.SetString("PlayersName", value);
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CurrentGame = new Game(lifes);
    }


    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NewGame()
    {
        CurrentGame = new Game(lifes);

        SceneManager.LoadScene("Stage 1");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
