using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[Header("SFX")]
	public AudioClip sfxBonus;
	public AudioClip sfxBounce;
	public AudioClip sfxGameOver;
	public AudioClip sfxLoseLife;
	public AudioClip sfxPenalty;
	public AudioClip sfxUIActivate;
	public AudioClip sfxUINavigate;
	
	public static AudioManager Instance { get; private set; }

	private AudioSource source;

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
		source = GetComponent<AudioSource>();
	}

	public void Play(AudioClip audio)
	{
		source.PlayOneShot(audio);
	}
}
