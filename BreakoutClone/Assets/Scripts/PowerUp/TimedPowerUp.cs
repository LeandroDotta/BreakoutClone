using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TimedPowerUp : PowerUp {
	public float time;
	private Text timeText;
	private float countdown;

	protected void Start()
	{
		timeText = transform.GetComponentInChildren<Text>();

		Apply();
	}

	protected override void Apply()
	{
		StartCoroutine("PowerUpCoroutine", time);
	}

	public void Prolong(float time){
		countdown += time;
	}

	public void Interrupt()
	{
		StopCoroutine("PowerUpCoroutine");
		PowerUpEnd();
		Destroy(gameObject);
	}

	protected abstract void PowerUpStart();
	protected abstract void PowerUpEnd();
	protected IEnumerator PowerUpCoroutine(float time)
    {
		countdown = time;

		PowerUpStart();

		do
		{
			timeText.text = countdown.ToString("0");
			
			yield return new WaitForEndOfFrame();

			countdown -= Time.deltaTime;
		}while(countdown > 0);

        PowerUpEnd();
		Destroy(gameObject);
    }
}
