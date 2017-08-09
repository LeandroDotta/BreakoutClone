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
	public bool IsEnabled { get; set; }
	public bool IsMusicEnabled { 
		get
		{
			return musicAudioSource.enabled;
		} 
		set
		{
			musicAudioSource.enabled = value;
		} 
	}

	private AudioSource source;
	private AudioSource musicAudioSource;

	void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		source = GetComponent<AudioSource>();
		musicAudioSource = transform.Find("Music").GetComponent<AudioSource>();
		
		print(musicAudioSource.name);
		IsEnabled = true;
	}

	public void Play(AudioClip audio)
	{
		if(IsEnabled)
			source.PlayOneShot(audio);
	}
}
