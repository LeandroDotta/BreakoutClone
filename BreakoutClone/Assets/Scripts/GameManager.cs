﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    Campaign,
    Hardcore,
    Free
}
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

            // if(StageManager.Instance != null)
            //     StageManager.Instance.SetScoreText(value);
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

    public string PlayerName { get; private set; }
    public GameMode Mode { get; set; }

    public Game(int lifeCount, GameMode mode)
    {
        Mode = mode;
        PlayerName = PlayerPrefs.GetString("PlayersName", "Dr. Breakout");

        if(mode == GameMode.Hardcore)
            LifeCount = 1;
        else
            LifeCount = lifeCount;
    }
}

public class GameManager : MonoBehaviour {
    public int lifes;

    public static GameManager Instance { get; set; }

    public Game CurrentGame { get; set; }
    public List<LeaderBoardItem> LeaderBoard { get; set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        CurrentGame = new Game(lifes, GameMode.Free);
        LoadLeaderBoard();
    }

    public void NewGame(GameMode mode)
    {
        CurrentGame = new Game(lifes, mode);
        //SceneManager.LoadScene("Stage 1");
    }

    public void LoadLeaderBoard()
    {
        LeaderBoard = new List<LeaderBoardItem>();

        for(int i = 0; i < 10; i++)
        {
            string keyName = string.Format("LeaderBoard[{0}].Name", i);
            string keyScore = string.Format("LeaderBoard[{0}].Score", i);

            if(PlayerPrefs.HasKey(keyName))
            {
                LeaderBoardItem item = new LeaderBoardItem()
                {
                    Name = PlayerPrefs.GetString(keyName),
                    Score = PlayerPrefs.GetInt(keyScore)
                };

                LeaderBoard.Add(item);
            }
            else
            {
                break;
            }
        }

        LeaderBoard = LeaderBoard.OrderByDescending(x => x.Score).ToList();
    }

    public bool AddScoreToLeaderBoard(int score)
    {
        bool result = false;

        for(int i = 0; i < 10; i++)
        {
            if(LeaderBoard.Count <= i)
            {
                LeaderBoard.Add(new LeaderBoardItem(){
                    Name = CurrentGame.PlayerName,
                    Score = score
                });

                result = true;
                break;
            }
            else
            {
                LeaderBoardItem item = LeaderBoard[i];

                if(score > item.Score)
                {
                    LeaderBoard.Insert(i, new LeaderBoardItem(){
                        Name = CurrentGame.PlayerName,
                        Score = score
                    });

                    result = true;
                    break;
                }
            }
        }

        if(result)
        {
            SaveLeaderBoard();
        }

        return result;
    }

    public void SaveLeaderBoard()
    {
        for(int i = 0; i < 10; i++)
        {
            if(i >= LeaderBoard.Count)
                break;

            LeaderBoardItem item = LeaderBoard[i];

            string keyName = string.Format("LeaderBoard[{0}].Name", i);
            string keyScore = string.Format("LeaderBoard[{0}].Score", i);

            PlayerPrefs.SetString(keyName, item.Name);
            PlayerPrefs.SetInt(keyScore, item.Score);
        }
    }

    public class LeaderBoardItem
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}