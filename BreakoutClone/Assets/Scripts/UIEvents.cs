using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void Play()
	{
		GameManager.Instance.NewGame();
	}


}
