using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class BooleanEvent : UnityEvent<bool> { }

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Text))]
public class ButtonToggleText : MonoBehaviour 
{
	public string onText;
	public string offText;

	public bool isOn = true;

	public BooleanEvent onToggle;

	
	private Button button;
	private Text textComponent;

	void Start()
	{
		textComponent = GetComponent<Text>();

		button = GetComponent<Button>();
		button.onClick.AddListener(ToggleTask);

		UpdateText();
	}

	private void ToggleTask()
	{
		isOn = !isOn;
		UpdateText();

		onToggle.Invoke(isOn);
	}

	private void UpdateText()
	{
		textComponent.text = isOn ? onText : offText;
	}
}
