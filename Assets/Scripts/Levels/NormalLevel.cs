using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NormalLevel : Level {
	
	protected bool CalculatePercentage(int PerctentageChance){
		bool percentage = false;

		int PercentageNumber = Random.Range (0, 100);
		if (PercentageNumber < PerctentageChance)
			percentage = true;

		return percentage;

	}



	protected void SameColor(List<Color> colors){
		int randomColor = Random.Range (0, colors.Count);
		ps.playerInfo.selectedColor = colors [randomColor];
		ps.computerInfo.selectedColor = colors [randomColor];
	}
	protected void AnotherColor(List<Color> colors){
		ACgoto:
		{
			int randomColorPlayer = Random.Range (0, colors.Count);
			int randomColorComputer = Random.Range (0, colors.Count);
			if (randomColorPlayer == randomColorComputer)
				goto ACgoto;
			else {
				ps.playerInfo.selectedColor = colors [randomColorPlayer];
				ps.computerInfo.selectedColor = colors [randomColorComputer];
			}
		}
	}
  

	protected void SameForm(List<Forms> forms){
		int randomForm = Random.Range (0, forms.Count);
		ps.playerInfo.selectedForm = forms [randomForm];
		ps.computerInfo.selectedForm = forms [randomForm];
	}

	protected void AnotherForm(List<Forms> forms){
		AFgoto:{

			int randomFormPlayer = Random.Range (0, forms.Count);
			int randomFormComputer = Random.Range (0, forms.Count);

			if (randomFormPlayer == randomFormComputer)
				goto AFgoto;
			else {
				ps.playerInfo.selectedForm = forms [randomFormPlayer];
				ps.computerInfo.selectedForm = forms [randomFormComputer];
			}
	
		}
	}
}
