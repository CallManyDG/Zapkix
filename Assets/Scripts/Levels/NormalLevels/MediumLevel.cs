using UnityEngine;
using System.Collections;

public class MediumLevel : NormalLevel {

	protected override void OnGame ()
	{
		ps = GameObject.Find ("GameSpace").GetComponent<PlayerScript> ();
		/*--------Form Inicializing-------------*/
		if (CalculatePercentage (60))
			SameForm (Forms);
		else
			AnotherForm (Forms);
		/*--------Color Inictializing-----------*/
		if (CalculatePercentage (70))
			SameColor (Colors);
		else
			AnotherColor (Colors);

		ps.playerInfo.resetScale = true;
		ps.computerInfo.resetScale = true;
	}
}
