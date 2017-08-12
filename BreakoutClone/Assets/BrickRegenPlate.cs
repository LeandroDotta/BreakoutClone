using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRegenPlate : MonoBehaviour {

	public GameObject sprites;
	public ParticleSystem particle;
	private Animator anim;

	public void Start()
	{
		anim = GetComponent<Animator>();
		particle.Stop();
	}

	public void Break()
	{
		sprites.SetActive(false);
		particle.Play();
	}

	public void Restore()
	{
		sprites.SetActive(true);
		anim.SetTrigger("restore");
		particle.Clear();
	}
}
