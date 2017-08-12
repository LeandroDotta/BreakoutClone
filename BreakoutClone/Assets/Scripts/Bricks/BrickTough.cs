using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTough : BrickNormal 
{
	[Range(1,3)]
	public int lifes = 3;

	[Header("Sprites")]
	public Sprite oneLifesSprite;
	public Sprite twoLifesSprite;
	public Sprite threeLifesSprite;

	protected SpriteRenderer spriteRenderer;
	

	protected override void Start()
	{
		base.Start();

		spriteRenderer = GetComponentInChildren<SpriteRenderer>();

		UpdateSprite();
	}

	protected override void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ball"))
        {
			RemoveLife();
        }
	}

	protected virtual void RemoveLife()
	{
		lifes--;	

		if(lifes <= 0)
		{
			DestroyBrick();
			return;
		}

		UpdateSprite();

		if(anim != null)
			anim.SetTrigger("getHit");
	}

	protected void UpdateSprite()
	{
		switch(lifes)
		{
			case 3:
				spriteRenderer.sprite = threeLifesSprite;
				break;
			case 2:
				spriteRenderer.sprite = twoLifesSprite;
				break;
			case 1:
			default:
				spriteRenderer.sprite = oneLifesSprite;
				break;
		}
	}
}
