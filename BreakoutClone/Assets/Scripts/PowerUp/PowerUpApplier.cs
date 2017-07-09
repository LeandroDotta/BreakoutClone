using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpApplier : MonoBehaviour {
	public PowerUp powerUpPrefab;

	private Text text;

	void Start()
	{
		text = transform.GetComponentInChildren<Text>();

		if(text != null)
		{
			if(powerUpPrefab.GetType() == typeof(ExtraScorePowerUp))
			{
				text.text = ((ExtraScorePowerUp)powerUpPrefab).score.ToString();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			
			PowerUpHolder.Instance.Add(powerUpPrefab);
			Destroy(gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Floor"))
		{
			Destroy(gameObject);
		}
	}
}
