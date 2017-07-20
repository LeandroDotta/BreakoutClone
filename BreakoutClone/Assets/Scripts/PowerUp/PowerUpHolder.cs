using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour {
	public static PowerUpHolder Instance { get; set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
	}

    public void Add(PowerUp powerUp)
    {
        if(powerUp is TimedPowerUp)
        {
            TimedPowerUp currentPowerUp = gameObject.GetComponentInChildren(powerUp.GetType()) as TimedPowerUp;

            if(currentPowerUp != null)
            {
                currentPowerUp.Prolong(currentPowerUp.time);
                return;
            }
        }

        PowerUp powerUpInstance = Instantiate(powerUp);
        powerUpInstance.name = powerUp.name;
        powerUpInstance.transform.SetParent(transform);
    }

    public void Remove<T>()
    {
        TimedPowerUp powerUp = gameObject.GetComponentInChildren<T>() as TimedPowerUp;

        if(powerUp != null)
        {
            powerUp.Interrupt();
        }
    }

    public void Clear()
    {
        TimedPowerUp[] powerUps = gameObject.GetComponentsInChildren<TimedPowerUp>();

        foreach(TimedPowerUp tpu in powerUps)
        {
            tpu.Interrupt();
        }
    }
}
