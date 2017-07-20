using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRegen : BrickTough 
{
	private IEnumerator RegenCoroutine()
	{
		while(lifes < 3)
		{
			yield return new WaitForSeconds(4);
			
			lifes++;
			UpdateSprite();
		}
	}

	protected override void RemoveLife()
	{
		StopCoroutine("RegenCoroutine");

		base.RemoveLife();

		StartCoroutine("RegenCoroutine");
	}
}
