using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRegen : BrickTough 
{
	public BrickRegenPlate plate1;
	public BrickRegenPlate plate2;
	public BrickRegenPlate plate3;
	public BrickRegenPlate plate4;

	private IEnumerator RegenCoroutine()
	{
		while(lifes < 3)
		{
			yield return new WaitForSeconds(4);
			
			lifes++;
			RestoreStep();

			//UpdateSprite();
		}
	}

	protected override void RemoveLife()
	{
		StopCoroutine("RegenCoroutine");

		base.RemoveLife();
		BreakStep();

		StartCoroutine("RegenCoroutine");
	}

	private void RestoreStep()
	{
		switch(lifes)
		{
			case 2:
				plate1.Restore();
				plate4.Restore();
				break;

			case 3:
				plate3.Restore();
				break;
		}
	}

	private void BreakStep()
	{
		switch(lifes)
		{
			case 0:
				plate2.Break();
				break;
			case 1:
				plate1.Break();
				plate4.Break();
				break;

			case 2:
				plate3.Break();
				break;
		}
	}
}
