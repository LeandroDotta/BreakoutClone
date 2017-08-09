using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour 
{ 
    private GameObject[] slots;
	public static PowerUpHolder Instance { get; set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
        slots = new GameObject[transform.childCount];
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
        }
    }

    public void Add(PowerUp powerUp)
    {
        if(powerUp.type == PowerUp.PowerUpType.Penalty)
            AudioManager.Instance.Play(AudioManager.Instance.sfxPenalty);
        else
            AudioManager.Instance.Play(AudioManager.Instance.sfxBonus);

        if(powerUp is TimedPowerUp)
        {
            TimedPowerUp currentPowerUp = gameObject.GetComponentInChildren(powerUp.GetType()) as TimedPowerUp;

            if(currentPowerUp != null)
            {
                currentPowerUp.Prolong(currentPowerUp.time);
                return;
            }
        }

        Transform slot = slots[GetNextFreeSlotIndex()].transform;

        PowerUp powerUpInstance = Instantiate(powerUp);
        powerUpInstance.name = powerUp.name;
        powerUpInstance.transform.position = slot.position;
        powerUpInstance.transform.SetParent(slot);
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

    private int GetNextFreeSlotIndex()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].transform.childCount == 0)
                return i;
        }

        return -1;
    }
}
