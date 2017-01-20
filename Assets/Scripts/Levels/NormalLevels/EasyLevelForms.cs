using UnityEngine;
using System.Collections;

public class EasyLevelForms : NormalLevel {

	protected override void OnGame ()
	{
		ps = GameObject.Find ("GameSpace").GetComponent<PlayerScript> ();
		SameColor (Colors);
		if (CalculatePercentage (65)) {
			SameForm (Forms);
		} else {
			AnotherForm (Forms);
		}
		ps.playerInfo.resetScale = true;
		ps.computerInfo.resetScale = true;

	}
}
