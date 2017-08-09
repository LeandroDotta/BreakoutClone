using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour 
{
	public ButtonToggleText buttonSound;
	public ButtonToggleText buttonMusic;

	void Start()
	{
		buttonSound.isOn = AudioManager.Instance.IsEnabled;
		buttonMusic.isOn = AudioManager.Instance.IsMusicEnabled;
	}
}
