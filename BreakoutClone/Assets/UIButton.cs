using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(Button))]
public class UIButton : MonoBehaviour, ISelectHandler
{
	private Button button;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

    public void OnSelect(BaseEventData eventData)
    {
        AudioManager.Instance.Play(AudioManager.Instance.sfxUINavigate);
    }

	void OnClick()
	{
		AudioManager.Instance.Play(AudioManager.Instance.sfxUIActivate);
	}
}
