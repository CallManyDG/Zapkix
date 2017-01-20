using UnityEngine;
using System.Collections;

public class EasyLevelColor : NormalLevel {


	protected override void OnGame ()
	{
		ps = GameObject.Find ("GameSpace").GetComponent<PlayerScript> ();
		SameForm (Forms);	
		if (CalculatePercentage (65)) {
			SameColor (Colors);
		} else {
			AnotherColor (Colors);
		}
	
		ps.playerInfo.resetScale = true;
		ps.computerInfo.resetScale = true;
	}


}
