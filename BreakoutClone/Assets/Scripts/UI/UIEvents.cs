using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour 
{
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

    public void PlayCampaign()
    {
        GameManager.Instance.NewGame(GameMode.Campaign);
    }
	public void PlayFreeMode()
	{
		GameManager.Instance.NewGame(GameMode.Free);
	}

    public void PlayHardcore()
    {
        GameManager.Instance.NewGame(GameMode.Hardcore);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextStage()
    {
        GameManager.Instance.CurrentGame.Score += StageManager.Instance.Score;

        if(!string.IsNullOrEmpty(StageManager.Instance.nextStage))
            SceneManager.LoadScene(StageManager.Instance.nextStage);
    }

    public void RestartStage()
    {
        if(GameManager.Instance.CurrentGame.Mode == GameMode.Campaign)
            GameManager.Instance.CurrentGame.LifeCount--;

        StageManager.Instance.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        GameManager.Instance.NewGame(GameManager.Instance.CurrentGame.Mode);

        if(GameManager.Instance.CurrentGame.Mode == GameMode.Free)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            SceneManager.LoadScene("01 - Stage");
    }

    public void ToggleSound(bool isOn)
    {
        AudioManager.Instance.IsEnabled = isOn;
    }

    public void ToggleMusic(bool isOn)
    {
        AudioManager.Instance.IsMusicEnabled = isOn;
    }

    public void PlayAudio(AudioClip audio)
    {
        AudioManager.Instance.Play(audio);
    }
}
