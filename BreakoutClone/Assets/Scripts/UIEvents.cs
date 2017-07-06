using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour {
	public void Play()
	{
		GameManager.Instance.NewGame();
	}
}
